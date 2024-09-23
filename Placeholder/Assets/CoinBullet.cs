using Assets.Scripts;
using UnityEngine;

public class CoinBullet : MonoBehaviour
{
    public float speed = 8f; // Speed of the projectile
    private Vector2 direction; // Direction of the projectile

    private void Start()
    {
        // Optional: Destroy the projectile after a certain time if it doesn't hit anything
        Destroy(gameObject, 2f);
    }

    // Call this method to set the direction
    public void Initialize(Vector2 firingDirection)
    {
        direction = firingDirection.normalized; // Normalize the direction
    }

    private void Update()
    {
        // Move the projectile in the set direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.CompareTag("Enemy"))
        {
            GoombaAI goomba = other.GetComponent<GoombaAI>();
            if (goomba != null)
            {
                goomba.Stun();
            }

            Destroy(gameObject); 
        }
    }
}
