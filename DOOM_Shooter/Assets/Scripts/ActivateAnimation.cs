using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseDown(0))
        {
            anim.SetTrigger("OnClick");
        }
    }
}
