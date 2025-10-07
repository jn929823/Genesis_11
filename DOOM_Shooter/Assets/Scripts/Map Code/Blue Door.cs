using UnityEngine;

public class BlueDoor : MonoBehaviour
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
            if (keys.haveBlueKey == true)
            {
                BlueDoorOpen();
            }
            else
            {
                return;
            }
        }
    }

    void BlueDoorOpen()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //play animation to open door
        }
    }
}
