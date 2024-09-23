using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 8f;
    public Animator animator;
    private IInventory inventory; // Declare inventory here
    private PlayerStatus playerStatus; // Declare player status here
    private ScoreManager scoreManager;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        inventory = GetComponent<IInventory>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        if (inventory != null && Input.GetKeyDown(KeyCode.X) && playerStatus.canCollect && !KirbyThrowAnimationPlayer())
        {
            SpawnProjectile();
            DeductScore(10);
            Debug.Log("Player has " + inventory.score + "G worth of items!");
        }
    }

    private bool KirbyThrowAnimationPlayer()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("KirbyThrow");
    }

    private void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        audioManager.PlaySFX(audioManager.Shoot);
        if (rb != null)
        {
            float direction = transform.localScale.x;
            rb.velocity = new Vector2(direction * projectileSpeed, 0);
        }
    }

    private void DeductScore(int amount)
    {
        if (scoreManager != null)
        {
            scoreManager.AddScore(-amount); // Deduct score using the ScoreManager
        }
        else
        {
            Debug.LogWarning("ScoreManager not found!");
        }
    }
}
