using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;
    private Rigidbody rb;
    public bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump == true)
            {
                PlayerJump();
            }
        }
    }
    void PlayerJump()
    {
        canJump = false;
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        Invoke("ResetJump", 2f);
    }
    void ResetJump()
    {
        canJump = true;
    }
}
