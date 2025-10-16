using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("GameObjects")]
    Rigidbody rb;
    public GameObject enemy;
    [Header("Health Floats")]
    public float currentEnemyHealth;
    public float maxEnemyHealth = 10;
    public float minEnemyHealth = 0;
    [Header("Outside Refrences")]
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public GameObject deathAudioPrefab;
    public Animator animator;
    public AudioSource hurtAudio;
    public SpriteRenderer idleSprite;
    public SpriteRenderer attackSprite;
    public SpriteRenderer hurtSprite;
    float timePassed = 0f;

    private void Start()
    {
        Idle();
        idleSprite.enabled = true;
        attackSprite.enabled = false;
        hurtSprite.enabled = false;
        GameObject player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            playerMovement = player.GetComponent<PlayerMovement>();
        }
        
        rb = GetComponent<Rigidbody>();
        currentEnemyHealth = maxEnemyHealth;
    }
    private void Update()
    {
        if (currentEnemyHealth == 0) 
        {
            playerMovement.SpeedIncrease();
            Destroy(enemy);

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
            EnemyTakeDamage(5);
            if (hurtAudio != null) hurtAudio.Play();
            if (timePassed > 1f)
            {
                Idle();
                timePassed = 0f;
            }
        }
        if (other.tag == "Player")
        {
            animator.SetBool("IsAttacking", true);
            idleSprite.enabled = false;
            attackSprite.enabled = true;
            hurtSprite.enabled = false;
            playerHealth.TakeDamage(10);
            if(timePassed > 1f)
            {
                Idle();
                timePassed = 0f;
            }
            
        }
    }
    void EnemyTakeDamage(float amount)
    {
        currentEnemyHealth -= amount;
        currentEnemyHealth = Mathf.Clamp(currentEnemyHealth, 0, maxEnemyHealth);
    }

    void Idle()
    {
        idleSprite.enabled = true;
        attackSprite.enabled = false;
        hurtSprite.enabled = false;
    }
}
