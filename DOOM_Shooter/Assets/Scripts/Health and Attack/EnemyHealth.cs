using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;
    public float currentEnemyHealth;
    public float maxEnemyHealth = 10;
    public float minEnemyHealth = 0;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }
    private void Update()
    {
        if (currentEnemyHealth <= 0) 
        { 
            Destroy(enemy);
            Debug.Log("enemy is slain");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            currentEnemyHealth -= 5;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
            Debug.Log("damage has been taken");
        }
    }
}
