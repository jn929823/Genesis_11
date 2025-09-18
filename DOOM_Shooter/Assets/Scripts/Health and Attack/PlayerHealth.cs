using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player; //set to character gameobject with a collider
    Rigidbody rb;
    public int currentHealth;
    public int maxHealth = 100; //change to balance
    public int minHealth = 0;
    //public Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
       //healthText = currentHealth;

    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //healthText.Text = currentHealth;
    }
    void Update()
    {
        if (currentHealth < minHealth)
        {
            Die();
        }

    }



    void Die()
    {
        //reset Scene
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (gameObject.tag == "enemy")
    //    {
    //        TakeDamage(10); //change to balance
    //    }
    //}
}
