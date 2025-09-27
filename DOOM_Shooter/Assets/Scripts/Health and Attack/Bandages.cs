using UnityEngine;

public class Bandages : MonoBehaviour
{
    [Header("Collisions")]
    Rigidbody rb;
    public GameObject bandage;
    public GameObject player;
    [Header("OutsideRefrences")]
    public PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UseBandage();
        }
    }
    void UseBandage()
    {
        playerHealth.TakeDamage(-20);
        Destroy(bandage);
    }
}
