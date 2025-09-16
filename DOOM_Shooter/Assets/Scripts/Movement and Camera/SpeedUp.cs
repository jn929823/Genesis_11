using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float speedBoost;
    public float speedMin = 3;
    PlayerMovement playerMovement;

    private void Start()
    {
        speedBoost = 0;
    }
    private void Update()
    {
        playerMovement.moveSpeed = playerMovement.moveSpeed + speedBoost;
    }
    public void IncreaseSpeed()
    {
        speedBoost += 1;
        Debug.Log("speed increased");
    }
}
