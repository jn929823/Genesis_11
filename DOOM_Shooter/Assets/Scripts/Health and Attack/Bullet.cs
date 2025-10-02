using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 15;
    private Vector3 velocity;

    public PlayerHealth playerHealth;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();

        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();

        Destroy(gameObject, 5);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector3 direction)
    {
        velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth.TakeDamage(10);
        }
    }
}
