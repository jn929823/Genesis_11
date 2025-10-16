using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class BossHealth : MonoBehaviour
{
    [Header("GameObjects")]
    Rigidbody rb;
    public GameObject Boss;
    [Header("Health Floats")]
    public float currentBossHealth;
    public float maxBossHealth = 100;
    public float minBossHealth = 0;
    [Header("Outside Refrences")]
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    [Header("Animation & Sound")]
    public GameObject deathAudioPrefab;
    public Animator animator;
    public AudioSource hurtAudio;
    public GameObject heavensLight;
    public SpriteRenderer idlingSprite;
    public SpriteRenderer hurtSprite;
    public SpriteRenderer squishSprite;
    float timePassed = 0f;


    private void Start()
    {
        Idles();
        if (heavensLight != null)
        {
            heavensLight.SetActive(false);
        }
        GameObject player = GameObject.Find("Player");
        animator = GetComponent<Animator>();

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMovement = player.GetComponent<PlayerMovement>();
        }

        rb = GetComponent<Rigidbody>();
        currentBossHealth = maxBossHealth;
    }
    private void Update()
    {
        if (currentBossHealth == 0)
        {
            playerMovement.SpeedIncrease();
            Destroy(Boss);
            if (heavensLight != null)
            {
                heavensLight.SetActive(true);
            }

            if (animator != null)
                animator.SetTrigger("IsDead");

            // Spawn and play death sound prefab
            if (deathAudioPrefab != null)
            {
                GameObject audioObj = Instantiate(deathAudioPrefab, transform.position, Quaternion.identity);
                AudioSource audioSource = audioObj.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                    Destroy(audioObj, audioSource.clip.length);
                }
                else
                {
                    Destroy(audioObj, 2f); // fallback destroy
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sword")
        {
            BossTakeDamage(5);
            if (hurtAudio != null) hurtAudio.Play();
            idlingSprite.enabled = false;
            squishSprite.enabled = false;
            hurtSprite.enabled = true;
            Invoke("Idles", 1f);

        }
        if (other.tag == "Player")
        {
            animator.SetBool("IsAttacking", true);
            playerHealth.TakeDamage(10);
        }
    }
    void BossTakeDamage(float amount)
    {
        currentBossHealth -= amount;
        currentBossHealth = Mathf.Clamp(currentBossHealth, 0, maxBossHealth);
    }

    public void Idles()
    {
        idlingSprite.enabled = true;
        squishSprite.enabled = false;
        hurtSprite.enabled = false;

    }
}
