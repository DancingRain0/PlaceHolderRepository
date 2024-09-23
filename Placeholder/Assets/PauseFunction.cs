using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the pause menu UI

    private bool isPaused = false;

    void Update()
    {
        // Check for pause/unpause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        isPaused = true;
        pauseMenu.SetActive(true); // Show the pause menu
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1; // Resume the game
        isPaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu
    }
}
