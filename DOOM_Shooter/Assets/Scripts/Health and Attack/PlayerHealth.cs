using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player; //set to character gameobject with a collider
    public float currentHealth;
    public float maxHealth = 100f; //change to balance
    public float minHealth = 1f;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(10); //change to balance
        }
    }
}
