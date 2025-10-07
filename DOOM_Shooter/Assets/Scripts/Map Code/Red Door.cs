using UnityEngine;

public class RedDoor : MonoBehaviour
{
    Rigidbody rb;
    Keys keys;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (keys.haveRedKey == true)
            {
                RedDoorOpen();
            }
            else
            {
                return;
            }
        }
    }

    void RedDoorOpen()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //play animation to open door
        }
    }
}
