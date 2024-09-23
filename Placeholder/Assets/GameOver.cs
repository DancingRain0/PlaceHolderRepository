using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text pointsText; // Use TMP_Text for TextMeshPro
    public GameObject gameOverPanel;
    private PlayerHealth playerHealth;
    private AudioManager audioManager; // Reference to the AudioManager

    private void Start()
    {
        // Ensure the panel is inactive at the start
        gameOverPanel.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>(); // Get the AudioManager
    }

    public void Setup(int score)
    {
        Debug.Log("Activating Game Over panel"); // Check if this appears
        gameOverPanel.SetActive(true);
        pointsText.text = "Gold: " + score.ToString();

        if (audioManager != null)
        {
            audioManager.StopMusic();
            audioManager.PlayMusic(audioManager.MainMenu); // Play the game over music
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name); // Reload the current scene
    }

    public void MainMenu()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene("Start screen"); // Replace with your main menu scene name
    }
}
