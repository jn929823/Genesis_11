using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player; //set to character gameobject with a collider
    Rigidbody rb;
    public int currentHealth;
    public int maxHealth = 100; //change to balance
    public int minHealth = 0;
    public Text currentHealthUI;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();

    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealthUI.text = $"{currentHealth}";

        if (currentHealth <= minHealth)
        {
            Die();
        }
    }

    void Die()
    {
        //reset Scene
        Debug.Log("You died.");
    }
}
