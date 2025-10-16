using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    private GameObject player;
    private GameObject playerObject;

    public float speed = 15;
    private Vector3 velocity;

    public PlayerHealth playerHealth;

    public AudioSource bulletAudio;

    void Start()
    {
        if (bulletAudio != null) bulletAudio.Play();
        player = GameObject.Find("Player");
        playerObject = GameObject.Find("PlayerObject");
        rb = GetComponent<Rigidbody>();

        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();

        Vector3 directionToPlayer = playerObject.transform.position - this.transform.position;

        this.transform.rotation = Quaternion.FromToRotation(this.transform.right, directionToPlayer) * this.transform.rotation;

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
            playerHealth.TakeDamage(5);
            Destroy(gameObject);
        }
        else if (other.tag == "Level")
        {
            Destroy(gameObject);
        }
    }
}
