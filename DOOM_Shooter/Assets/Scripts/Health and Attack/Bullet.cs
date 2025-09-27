using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 15;
    private Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

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
}
