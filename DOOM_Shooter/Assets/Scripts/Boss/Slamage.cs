using UnityEngine;

public class Slamage : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealth playerHealth;

    //private void Start()
    //{
    //    GameObject player = GameObject.Find("Player");

    //    if (player != null)
    //    {
    //        playerHealth = player.GetComponent<PlayerHealth>();
    //    }
    //}

    public void OnTriggerEnter(Collider other)
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
