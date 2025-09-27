using UnityEngine;

public class RangeMovement : EnemyMovement
{
    public GameObject bullet;
    public float rateOfFire = 0.5f;
    private float shootTimer = 0;

    private void Start()
    {
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

    private bool TargetAttackable()
    {
        Vector3 flatDirToTarget = new Vector3(dirToTarget.x, 0, dirToTarget.z).normalized;

        if (CanSeeTarget() && distance <= 15) 
        {
            return true;
        }
        else
            return false;
    }
}
