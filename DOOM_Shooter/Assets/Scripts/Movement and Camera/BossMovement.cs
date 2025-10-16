using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    Rigidbody rb;

    //Player
    public GameObject target;
    public Vector3 origin = Vector3.zero;
    public Vector3 dirToTarget = Vector3.zero;
    public Vector3 horizontalDir = Vector3.zero;

    //NavMesh
    public NavMeshAgent navAgent;
    public float distance;
    public float stoppingDistance = 30f; //Make this equal to the distance where the boss does a slam attack

    public GameObject bullet;
    public float rateOfFire = 0.3f;
    private float shootTimer = 0;

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.stoppingDistance = stoppingDistance;

        target = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;
        else
        {
            dirToTarget = (target.transform.position - transform.position).normalized;

            if (TargetAttackable())
            {
                shootTimer = rateOfFire;

                GameObject newBullet = Instantiate(bullet);

                newBullet.transform.position = transform.position;

                newBullet.GetComponent<Bullet>().SetVelocity(dirToTarget);
            }
        }
    }

    public void FixedUpdate()
    {
        //Find the position of the enemy
        origin = transform.position;

        //origin.y = -15;

        //Finds the direction from the transform to the target
        dirToTarget = (target.transform.position - origin);

        //Sets the y direction to 0
        /*dirToTarget.y = 0;*/

        //Normalize the dirToTarget to get the horizontal direction w/o the y direction
        horizontalDir = dirToTarget.normalized;

        transform.LookAt(target.transform);

        //Calls CanSeeTarget to use raycast
        if (CanSeeTarget())
        {
            navAgent.SetDestination(target.transform.position);
        }
    }

    public bool CanSeeTarget()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        RaycastHit hit;
        if (Physics.Raycast(origin, horizontalDir, out hit, distance))
        {
            if (hit.collider.gameObject == target || hit.collider.tag == "enemy")
            {
                Debug.Log("Distance: " + distance);
                return true;
            }
        }
        return false;
    }

    private bool TargetAttackable()
    {
        Vector3 flatDirToTarget = new Vector3(dirToTarget.x, 0, dirToTarget.z).normalized;

        if (CanSeeTarget() && distance <= 50)
        {
            return true;
        }
        else
            return false;
    }

    public bool GroundSlamable()
    {
        Vector3 flatDirToTarget = new Vector3(dirToTarget.x, 0, dirToTarget.z).normalized;

        if (CanSeeTarget() && distance <= 50)
        {
            return true;
        }
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + horizontalDir * 20);
    }
}
