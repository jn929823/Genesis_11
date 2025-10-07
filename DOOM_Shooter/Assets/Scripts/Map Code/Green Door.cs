using UnityEngine;

public class GreenDoor : MonoBehaviour
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
            if (keys.haveGreenKey == true)
            {
                GreenDoorOpen();
            }
            else
            {
                return;
            }
        }
    }

    void GreenDoorOpen()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //play animation to open door
        }
    }
}
