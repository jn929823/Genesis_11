using UnityEngine;
using UnityEngine.UIElements;

public class RangeAttack : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public float rateOfFire = 0.5f;
    private float shootTimer = 0;
    private Vector3 dirToTarget = Vector3.zero;
    public EnemyMovement enemyMovement;



    private void Start()
    {
        target = GameObject.Find("PlayerObject");
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            enemyMovement = player.GetComponent<EnemyMovement>();
        }
    }

    void Update()
    {
        if (shootTimer > 0) //And can see player/ is in range
            shootTimer -= Time.deltaTime;
        else
        {
            dirToTarget = (target.transform.position - transform.position).normalized;

            if (TargetInView())
            {
                shootTimer = rateOfFire;

                GameObject newBullet = Instantiate(bullet);

                newBullet.transform.position = transform.position;

                newBullet.GetComponent<Bullet>().SetVelocity(dirToTarget);
            }
        }
    }

    private bool TargetInView()
    {
        Vector3 flatDirToTarget = new Vector3(dirToTarget.x, 0, dirToTarget.z).normalized;

        if (enemyMovement.CanSeeTarget()) //ADD IF THE PLAYER IS IN RANGE
        {
            return true;
        }
        else
            return false;
    }
}
