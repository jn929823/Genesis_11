using Unity.VisualScripting;
using UnityEngine;

public class GroundSlam : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject hitbox;
    Rigidbody boss;
    public GameObject player;
    [Header("bools")]
    bool isSlamming;
    bool isGrounded;
    bool airborne;
    [Header("Outside Refrences")]
    PlayerHealth playerHealth;
    public BossMovement bossMovement;
    [Header("Animation")]
    public Animator animator;
    public GameObject pentagram;
    public SpriteRenderer idlingSprite;
    public SpriteRenderer hurtSprite;
    public SpriteRenderer squishSprite;
    public SpriteRenderer pentagramSprite;

    void Start()
    {
        Idles();
        pentagram.SetActive(false);
        hitbox.SetActive(false);
        boss = GetComponent<Rigidbody>();
        GameObject player = GameObject.Find("Player");
        isSlamming = false;
        airborne = false;

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    private void Update()
    {
        if (bossMovement.GroundSlamable() && isSlamming == false)
        {
            Squish();
            Debug.Log("If Statement");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    void Squish()
    {
        isSlamming = true;
        idlingSprite.enabled = false;
        squishSprite.enabled = true;
        hurtSprite.enabled = false;
        pentagramSprite.enabled = true;
        pentagram.SetActive(true);
        Invoke("StartSlam", 4f);
        Debug.Log("Squished");
    }
    void StartSlam()
    {
        pentagram.SetActive(false);
        hitbox.SetActive(true);
        Idles();
        Debug.Log("Slammed");
        Invoke("EndSlam", 0.1f);
    }
    void EndSlam()
    {
        hitbox.SetActive(false);
        isSlamming = false;
        Debug.Log("Done");
    }

    public void Idles()
    {
        idlingSprite.enabled = true;
        squishSprite.enabled = false;
        hurtSprite.enabled = false;
        pentagramSprite.enabled = false;

    }
}
