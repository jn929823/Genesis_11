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
    public Text gameOverText;
    public Button retryButton;
    public Button quitButton;
    public GameObject gameOverScreen;
    public GameObject notgameOver;

    void Start()
    {
        notgameOver.SetActive(true);
        gameOverScreen.SetActive(false);
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




    private void RestartGame()
    {

        SceneManager.LoadScene("Level");
        Debug.Log("Restarted");

    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("its over");
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

    private IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(1f);
        gameOverScreen.SetActive(true);
        notgameOver.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverText.CrossFadeAlpha(1f, 1f, false);
        retryButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Die()
    {

        StartCoroutine(ShowGameOverScreen());
        GetComponent<PlayerMovement>().enabled = false;
        //StartCoroutine(CameraFall());
    }
}
