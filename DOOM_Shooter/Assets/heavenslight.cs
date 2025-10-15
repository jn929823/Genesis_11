using UnityEngine;
using UnityEngine.SceneManagement;

public class heavenslight : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad = "Game Complete"; // Name of the scene to load

    [Header("Player Tag")]
    public string playerTag = "Player"; // Tag used to detect the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player entered portal — loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
