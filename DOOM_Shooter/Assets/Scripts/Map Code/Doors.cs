using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool nearDoor;

    private void Start()
    {
        nearDoor = false;
    }
    private void Update()
    {
        if (nearDoor == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //play animation to open door
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearDoor = false;
        }
    }
}
