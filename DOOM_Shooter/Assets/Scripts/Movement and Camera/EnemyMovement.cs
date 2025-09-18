using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    private Vector3 dirToTarget = Vector3.zero;
    private Vector3 horizontalDir = Vector3.zero;
    Rigidbody rb;
    private float radius = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Finds the direction from the transform to the target
        dirToTarget = (target.transform.position - transform.position);
        //Sets the y direction to 0
        dirToTarget.y = 0;
        //Normalize the dirToTarget to get the horizontal direction w/o the y direction
        horizontalDir = dirToTarget.normalized;
    }

    void FixedUpdate()
    {
        //Finds the player's position, uses its own y position so it doesn't travel upward
        Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        //Move the enemy toward the player
        transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 3 * Time.deltaTime);
        //Rotate the enemy toward the player
        transform.rotation = Quaternion.LookRotation(horizontalDir, Vector3.up);

        //Still need to check for if in range for ranged enemies
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + horizontalDir * 2);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, radius);
    }
}
