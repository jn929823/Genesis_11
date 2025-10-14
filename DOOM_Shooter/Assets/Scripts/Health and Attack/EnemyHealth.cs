using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("GameObjects")]
    Rigidbody rb;
    public GameObject enemy;
    [Header("Health Floats")]
    public float currentEnemyHealth;
    public float maxEnemyHealth = 10;
    public float minEnemyHealth = 0;
    [Header("Outside Refrences")]
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public AudioSource audioSource;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMovement = player.GetComponent<PlayerMovement>();
        }
        
        rb = GetComponent<Rigidbody>();
        currentEnemyHealth = maxEnemyHealth;
    }
    private void Update()
    {
        if (currentEnemyHealth == 0) 
        {
            playerMovement.SpeedIncrease();
            Destroy(enemy);
            audioSource.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sword")
        {
            EnemyTakeDamage(5);
        }
        if (other.tag == "Player")
        {
            playerHealth.TakeDamage(10);
            
        }
    }
    void EnemyTakeDamage(float amount)
    {
        currentEnemyHealth -= amount;
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
    }
}
