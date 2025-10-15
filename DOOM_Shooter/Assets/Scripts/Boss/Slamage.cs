using UnityEngine;

public class Slamage : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerHealth playerHealth;
    GameObject player;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigger");

        if (other.tag == "Player")
        {
            Debug.Log("PreDamage");
            playerHealth.TakeDamage(50);
            Debug.Log("Damage");
        }
    }
}
