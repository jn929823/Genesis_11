using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody rb;
    public GameObject enemy;
    public float currentEnemyHealth;
    public float maxEnemyHealth = 10;
    public float minEnemyHealth = 0;
    public PlayerMovement PlayerMovement;
    public PlayerHealth PlayerHealth;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        
        if(player != null)
        {
            PlayerHealth = player.GetComponent<PlayerHealth>();
            PlayerMovement = player.GetComponent<PlayerMovement>();
        }
        
        rb = GetComponent<Rigidbody>();
        currentEnemyHealth = maxEnemyHealth;
    }
    private void Update()
    {
        if (currentEnemyHealth == 0) 
        {
            PlayerMovement.SpeedIncrease();
            Destroy(enemy);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyTakeDamage(5);
            PlayerHealth.TakeDamage(10);

        }
    }
    void EnemyTakeDamage(float amount)
    {
        currentEnemyHealth -= amount;
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
    }
}
