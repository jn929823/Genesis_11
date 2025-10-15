using Unity.VisualScripting;
using UnityEngine;

public class Keys : MonoBehaviour
{
    //Parkour Key
    [Header("Green Key")]
    public bool haveGreenKey;
    public GameObject greenKey;
    GameObject greenDoor;

    //Maze Key
    [Header("Yellow Key")]
    public bool haveYellowKey;
    public GameObject yellowKey;
    GameObject yellowDoor;

    //Boss Key
    [Header("Red Key")]
    public bool haveRedKey;
    public GameObject redKey;
    GameObject redDoor;
    
    void Start()
    {
        haveGreenKey = false;
        haveYellowKey = false;
        haveRedKey = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenKey"))
        {
            greenKey.SetActive(false);
            haveGreenKey = true;
        }
        if (other.CompareTag("YellowKey"))
        {
            yellowKey.SetActive(false);
            haveYellowKey = true;
        }
        if (other.CompareTag("RedKey"))
        {
            redKey.SetActive(false);
            haveRedKey = true;
        }
    }
}
