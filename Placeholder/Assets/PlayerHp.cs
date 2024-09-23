using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int HP = 3; // Starting health
    public int MaxHP = 3; // Maximum health
    public int Lives = 3; // Number of lives
    public TMP_Text livesText; // Reference to the UI text for lives

    private HealthBar _healthBar; // Reference to the HealthBar
    private LivesCounter _livesCounter; // Reference to the LivesCounter
    private GameOver _gameOver; // Reference to the GameOver UI
    private Invintory _inventory; // Reference to the Inventory

    private void Start()
    {
        _healthBar = FindObjectOfType<HealthBar>();
        _livesCounter = FindObjectOfType<LivesCounter>();
        _gameOver = FindObjectOfType<GameOver>();
        _inventory = FindObjectOfType<Invintory>(); // Find the Inventory class
        ResetHealth();
        UpdateLivesUI();
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Lives -= 1;
            if (Lives > 0)
            {
                ResetHealth();
            }
            else
            {
                HandleGameOver(); // Ensure this gets called when lives are 0
            }
        }
        UpdateLivesUI();
        _healthBar.SetValue(HP);
    }

    private void ResetHealth()
    {
        HP = MaxHP;
        if (_healthBar != null)
        {
            _healthBar.SetValue(HP);
        }
    }

    private void UpdateLivesUI()
    {
        if (_livesCounter != null)
        {
            _livesCounter.UpdateLives(Lives);
        }
    }

    public void HandleGameOver()
    {
        Debug.Log("Game Over triggered"); // Check if this appears in the console
        if (_gameOver != null)
        {
            _gameOver.Setup(_inventory.score); // Use the inventory score here
        }
    }
}
