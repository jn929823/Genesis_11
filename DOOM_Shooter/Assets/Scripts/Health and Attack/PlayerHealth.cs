using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player; //set to character gameobject with a collider
    Rigidbody rb;
    public int currentHealth;
    public int maxHealth = 100; //change to balance
    public int minHealth = 0;
    public Text currentHealthUI;
    public GameObject playerCamera;

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

    private IEnumerator CameraFall()
    {
        float fallSpeed = 5f;
        Vector3 initialPosition = playerCamera.transform.position;
        Vector3 fallPosition = new Vector3(initialPosition.x, initialPosition.y - 10f, initialPosition.z);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * fallSpeed;
            playerCamera.transform.position = Vector3.Lerp(initialPosition, fallPosition, t);
            yield return null;
        }
    }

    void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(CameraFall());
    }
}
