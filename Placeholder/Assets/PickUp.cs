using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int scoreValue = 50;
    public ScoreManager scoreScript;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        // Get the ScoreManager instance from the scene
        scoreScript = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IInventory inventory = other.GetComponent<IInventory>();
            PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();

            if (inventory != null && playerStatus != null)
            {
                Debug.Log("Can Collect: " + playerStatus.canCollect);

                if (playerStatus.canCollect)
                {
                    inventory.score += scoreValue;
                    Debug.Log("Player has " + inventory.score + "G worth of items!");
                    gameObject.SetActive(false);
                    scoreScript.AddScore(scoreValue);
                    audioManager.PlaySFX(audioManager.Pickup);
                }
                else
                {
                    Debug.Log("Player cannot collect items right now.");
                }
            }
            else
            {
                Debug.Log("Missing IInventory or PlayerStatus component.");
            }
        }
    }
}