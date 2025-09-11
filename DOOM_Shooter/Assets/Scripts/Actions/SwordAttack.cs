using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Rigidbody rb;
    public GameObject sword;
    bool isAttacking;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        sword.SetActive(false);

        isAttacking = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isAttacking == false)
            {
                isAttacking = true;
                sword.SetActive(true);
                //sword animations and sounds
                Invoke("AttackCleanup", 1f);
            }
        }
    }
    void AttackCleanup()
    {
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            // animations and sounds for succesful hit
        }
    }
}
