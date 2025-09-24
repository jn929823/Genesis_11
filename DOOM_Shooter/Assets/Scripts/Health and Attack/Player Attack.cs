using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject sword;
    void Start()
    {

        sword.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 


            Attack();
        }
    }
    void Attack()
    {
        sword.SetActive(true);
        Invoke("FinishAttack", 2.0f);
        Debug.Log("starting attack");
    }
    void FinishAttack()
    {
        sword.SetActive(false);
        Debug.Log("finished attack");
    }
}
