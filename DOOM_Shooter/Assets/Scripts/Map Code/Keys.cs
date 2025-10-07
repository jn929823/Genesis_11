using Unity.VisualScripting;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [Header("Green Key")]
    public bool haveGreenKey;
    public GameObject greenKey;
    [Header("Blue Key")]
    public bool haveBlueKey;
    public GameObject blueKey;
    [Header("Red Key")]
    public bool haveRedKey;
    public GameObject redKey;
    void Start()
    {
        haveGreenKey = false;
        haveBlueKey = false;
        haveRedKey = false;
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
