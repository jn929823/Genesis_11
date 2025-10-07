using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    [Header("GameObjects")]
    GameObject hitbox;
    public GameObject player;
    [Header("Outside Refrences")]
    PlayerHealth playerHealth;

    void Start()
    {
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
            playerHealth.TakeDamage(10);
        }
    }
}
