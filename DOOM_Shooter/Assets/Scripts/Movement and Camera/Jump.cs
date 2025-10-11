using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;
    private Rigidbody rb;
    public bool canJump = true;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump == true && IsGrounded())
            {
                PlayerJump();
            }
        }
    }

    void PlayerJump()
    {
        canJump = false;
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        Invoke("ResetJump", 1f);
    }
    void ResetJump()
    {
        canJump = true;
    }

    bool IsGrounded()
    {
        if (rb.linearVelocity.y == 0)
            return true;
        else
            return false;
    }
}
