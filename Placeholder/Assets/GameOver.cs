using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameOver : MonoBehaviour
{
    public TMP_Text pointsText; // Use TMP_Text for TextMeshPro
    public GameObject gameOverPanel;

    private void Start()
    {
        // Ensure the panel is inactive at the start
        gameOverPanel.SetActive(false);
    }

    public void Setup(int score)
    {
        Debug.Log("Activating Game Over panel"); // Check if this appears
        gameOverPanel.SetActive(true);
        pointsText.text = "Gold: " + score.ToString();
        Time.timeScale = 0;
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
