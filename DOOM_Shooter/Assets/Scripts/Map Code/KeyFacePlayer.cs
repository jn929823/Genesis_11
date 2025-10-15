using UnityEngine;

public class KeyFacePlayer : MonoBehaviour
{
    public GameObject player;

    public void FixedUpdate()
    {
        transform.LookAt(player.transform);
    }
}
