using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script
    public Transform startPosition; // Reference to the starting position of the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HandleDeath(other.transform); // Pass the player's transform to HandleDeath
        }
    }

    private void HandleDeath(Transform playerTransform)
    {
        if (playerHealth != null)
        {

            if (playerHealth.Lives > 0)
            {
                playerHealth.TakeDamage(playerHealth.HP);
                playerTransform.position = startPosition.position;
            }
        }
    }
}
