using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject sword;
    bool isAttacking;


    private void Start()
    {
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
        sword.SetActive(false);
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
