using Unity.VisualScripting;
using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject hitbox;
    Rigidbody boss;
    public GameObject player;
    [Header("bools")]
    bool isSlamming;
    bool isGrounded;
    bool airborne;
    [Header("Outside Refrences")]
    PlayerHealth playerHealth;
    public BossMovement bossMovement;
    [Header("Animation")]
    public Animator animator;

    void Start()
    {
        hitbox.SetActive(false);
        boss = GetComponent<Rigidbody>();
        GameObject player = GameObject.Find("Player");
        isSlamming = false;
        airborne = false;

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    private void Update()
    {
        if (bossMovement.GroundSlamable() && isSlamming == false)
        {
            Squish();
            Debug.Log("If Statement");
        }

        if (isGrounded == true && airborne == true)
        {
            airborne = false;
            StartSlam();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    void Squish()
    {
        isSlamming = true;
        // squish annimation last 4 seconds
        Invoke("GroundSlamAttack", 4f);
        Debug.Log("Squished");
    }
    void GroundSlamAttack()
    {
        // end squish animation
        boss.AddForce(Vector3.up * 2, ForceMode.Impulse);//Change the two if boss jump needs adjusting
        airborne = true;
    }
    void StartSlam()
    {
        hitbox.SetActive(true);
        Debug.Log("Slammed");
        Invoke("EndSlam", 0.1f);
    }
    void EndSlam()
    {
        hitbox.SetActive(false);
        isSlamming = false;
        Debug.Log("Done");
    }
}
