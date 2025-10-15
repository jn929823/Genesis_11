using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject greenDoor;
    public GameObject yellowDoor;
    public GameObject redDoor;

    private Keys keys;

    private void Start()
    {
        keys = GetComponent<Keys>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenDoor") && keys.haveGreenKey)
        {
            greenDoor.SetActive(false);
        }

        if (other.CompareTag("YellowDoor") && keys.haveYellowKey)
        {
            yellowDoor.SetActive(false);
        }

        if (other.CompareTag("RedDoor") && keys.haveRedKey)
        {
            redDoor.SetActive(false);
        }

        if (other.CompareTag("RedDoorClose"))
        {
            redDoor.SetActive(true);
        }
    }
}
