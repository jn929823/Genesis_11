using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;
    private Rigidbody rb;
    public bool isGrounded = true;
    public AudioSource jumpAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                PlayerJump();
                if (jumpAudio != null) jumpAudio.Play();
            }
        }
    }

    void PlayerJump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
