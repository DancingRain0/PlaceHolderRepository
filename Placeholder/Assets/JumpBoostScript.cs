using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class JumpBoostScript : MonoBehaviour
{
    [SerializeField] private float boostAmount = 12f;  // Amount of boost to add to jump power
    [SerializeField] private float boostDuration = 5f; // Duration of the boost effect

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                StartCoroutine(ApplyBoost(playerMovement));
            }
            Destroy(gameObject); // Destroy the boost item after it has been used
        }
    }

    private IEnumerator ApplyBoost(PlayerMovement playerMovement)
    {
        // Apply the boost
        playerMovement.SetJumpBoost(boostAmount);

        // Wait for the boost duration
        yield return new WaitForSeconds(boostDuration);

        // Reset the jump power after the boost duration
        playerMovement.Resetjumpingpower();
    }
}
