using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeSystem : MonoBehaviour
{
    public int maxLives = 3; // Maximum lives the player starts with
    private int currentLives; // Current number of lives

    public Transform respawnPoint; // The respawn location

    void Start()
    {
        currentLives = maxLives; // Initialize lives
    }

    public void PlayerDied()
    {
        currentLives--;

        if (currentLives > 0)
        {
            Respawn();
        }
        else
        {
            ReturnToTitleScreen();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position; // Move player to the respawn point
        Debug.Log($"Player respawned. Lives remaining: {currentLives}");
    }

    private void ReturnToTitleScreen()
    {
        Debug.Log("Returning to title screen...");
        SceneManager.LoadScene("Start"); 
        }
}
