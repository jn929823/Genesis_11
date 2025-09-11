using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody rb;
    public float currentEnemyHealth;
    public float maxEnemyHealth = 10;
    public float minEnemyHealth = 1;
    public PlayerMovement PlayerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentEnemyHealth = maxEnemyHealth;
    }
    private void Update()
    {
        if (currentEnemyHealth < minEnemyHealth) 
        {
            PlayerMovement.SpeedIncrease();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sword")
        {
            EnemyTakeDamage(5);
        }
    }
    void EnemyTakeDamage(float amount)
    {
        currentEnemyHealth -= amount;
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
    }
}
