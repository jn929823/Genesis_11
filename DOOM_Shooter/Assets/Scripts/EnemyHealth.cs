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
        if (currentEnemyHealth < minEnemyHealth) 
        { 
            Destroy(enemy);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "sword")
        {
            currentEnemyHealth -= 5;
            currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
        }
    }
}
