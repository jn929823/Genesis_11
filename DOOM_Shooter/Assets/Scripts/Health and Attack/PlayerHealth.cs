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
    public AudioSource hitsoundAudio;
    public AudioSource gameOverAudio;

    //Poison Dmg/Time
    private float damageInterval = 0.75f;
    private float nextDamageTick;

    void Start()
    {
        notgameOver.SetActive(true);
        gameOverScreen.SetActive(false);
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        nextDamageTick = Time.time;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (hitsoundAudio != null) hitsoundAudio.Play();
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealthUI.text = $"{currentHealth}";

        if (currentHealth <= minHealth)
        {
            if (gameOverAudio != null) gameOverAudio.Play();

            Die();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Poison"))
        {
            if (Time.time >= nextDamageTick)
            {
                TakeDamage(2);

                nextDamageTick = Time.time + damageInterval;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            TakeDamage(10000);
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
