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
            if (canJump == true /*&& IsGrounded()*/)  //Uncomment when IsGrounded works properly
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

    /*bool IsGrounded()
    {
        //Needs some kind of raycast check
    }*/
}
