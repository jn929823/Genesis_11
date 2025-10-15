using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject hitbox;
    Rigidbody boss;
    public GameObject player;
    [Header("bools")]
    bool isSlamming;
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
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        playerHealth.TakeDamage(50);
    //    }
    //}
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
        // boss.AddForce(Vector3.up * 2, ForceMode.Impulse);  //Change the two if boss jump needs adjusting
        hitbox.SetActive(true);
        Debug.Log("Slammed");
        EndSlam();
    }
    void EndSlam()
    {
        hitbox.SetActive(false);
        isSlamming = false;
        Debug.Log("Done");
    }
}
