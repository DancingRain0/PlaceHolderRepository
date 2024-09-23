using TMPro;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public TMP_Text livesText; // Reference to the TextMeshPro component

    private void Start()
    {
        // Ensure the lives text is initialized
        if (livesText == null)
        {
            livesText = GetComponent<TMP_Text>();
        }
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives; // Update the text to show current lives
    }
}
