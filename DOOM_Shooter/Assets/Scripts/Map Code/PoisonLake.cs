using UnityEngine;

public class PoisonLake : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;

    public bool isDying;
    public bool notDying;
    
    public PlayerHealth playerHealth;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isDying = true;
            TickDamage();
        }
    }
    void TickDamage()
    {
        if (isDying == true)
        {
            playerHealth.TakeDamage(5);
            Invoke("TickDamage", 1f);
        }
        else
        {
            return;
        }
    }
}
