using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player; //set to character gameobject with a collider
    Rigidbody rb;
    public float currentHealth;
    public float maxHealth = 100f; //change to balance
    public float minHealth = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (currentHealth < minHealth)
        {
            Die();
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
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
