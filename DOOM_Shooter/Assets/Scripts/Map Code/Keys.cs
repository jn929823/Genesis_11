using Unity.VisualScripting;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [Header("Green Key")]
    public bool haveGreenKey;
    public GameObject greenKey;
    GameObject greenDoor;
    [Header("Blue Key")]
    public bool haveBlueKey;
    public GameObject blueKey;
    GameObject blueDoor;
    [Header("Red Key")]
    public bool haveRedKey;
    public GameObject redKey;
    GameObject redDoor;
    
    void Start()
    {
        haveGreenKey = false;
        haveBlueKey = false;
        haveRedKey = false;
    }
    void Update()
    {
        
        if (haveGreenKey == true)
        {
            Doors greenDoors = greenDoor.GetComponent<Doors>();
            greenDoors.enabled = true;
        }   
        if (haveBlueKey == true)
        {
            Doors bluedoors = blueDoor.GetComponent<Doors>();
            bluedoors.enabled = true;
        }
        if (haveRedKey == true)
        {
            Doors redDoors= redDoor.GetComponent<Doors>();
            redDoors.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (tag.Contains("GreenKey"))
        {
            greenKey.SetActive(false);
            haveGreenKey = true;
        }
        if (tag.Contains("BlueKey"))
        {
            blueKey.SetActive(false);
            haveBlueKey = true;
        }
        if (tag.Contains("RedKey"))
        {
            redKey.SetActive(false);
            haveRedKey = true;
        }
    }
}
