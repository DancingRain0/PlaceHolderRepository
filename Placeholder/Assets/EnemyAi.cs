using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] patrolPoints;
    public float stunDuration = 2f;

    private int currentPatrolIndex = 0;
    private bool isFacingRight = true;
    private bool isStunned = false;
    private Animator animator; 

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        if (!isStunned)
        {
            Patrol();
            animator.SetBool("isStunned", false); 
        }
        else if (isStunned)
        {
            animator.SetBool("isStunned", true);
        }
    }

    private void Patrol()
    {
       
        Transform target = patrolPoints[currentPatrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Stun();
            Destroy(other.gameObject); // Destroy the projectile
        }
        else if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Reduce player health by 1
            }
        }
    }

    public void Stun() 
    {
        isStunned = true;
        StartCoroutine(StunCoroutine());
    }

    private IEnumerator StunCoroutine()
    {
        yield return new WaitForSeconds(stunDuration); 
        isStunned = false; 
    }
}
