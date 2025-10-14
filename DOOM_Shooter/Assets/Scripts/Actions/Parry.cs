using UnityEngine;

public class Parry : MonoBehaviour
{
    public PlayerHealth health;
    
    public bool isParrying;
    public AudioSource parryAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetEnd();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ParryStart();
        }
    }
    void ParryStart()
    {
        isParrying = true;
        if (parryAudio != null) parryAudio.Play();

        // disable attack
        Invoke("ResetParry", 2f);
        Invoke("ParryCooldown", 5f);
    }
    void ResetEnd()
    {
        isParrying = false;
        // enable attack
    }
    void ParryCooldown()
    {
        
    }
}
