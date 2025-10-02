using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public Vector3 origin = Vector3.zero;
    public Vector3 dirToTarget = Vector3.zero;
    public Vector3 horizontalDir = Vector3.zero;
    public NavMeshAgent navAgent;
    public float distance;
    Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("PlayerObject");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void FixedUpdate()
    {
        //Find the position of the enemy
        origin = transform.position;

        //Finds the direction from the transform to the target
        dirToTarget = (target.transform.position - origin);

        //Sets the y direction to 0
        dirToTarget.y = 0;

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
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + horizontalDir * 2);
    }
}
