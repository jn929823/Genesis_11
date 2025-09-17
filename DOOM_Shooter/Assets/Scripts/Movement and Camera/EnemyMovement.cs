using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    private Vector3 dirToTarget = Vector3.zero;
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
        dirToTarget = (target.transform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 3 * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + dirToTarget * 2);

        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, radius);
    }
}
