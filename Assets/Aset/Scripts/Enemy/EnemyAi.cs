using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public float speed = 3f;

    [SerializeField]
    public float detectionRange = 10f;

    [SerializeField]
    public float rotationSpeed = 200f;

    [SerializeField]
    public Transform point; // Reference to the blade (assumed to be at player's position)

    [SerializeField]
    public float bladeRange = 3f;

    [SerializeField]
    private Rigidbody2D rb;

    public float health = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        float distanceToBlade = Vector2.Distance(transform.position, point.position); // Assuming point is at player's position

        if (distanceToPlayer <= detectionRange)
        {
            RotateTowardsPlayer();

            if (distanceToBlade > bladeRange) // If the blade is not too close, move towards the player
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop moving if the player is out of detection range
            rb.angularVelocity = 0f; // Stop rotating if the player is out of detection range
        }
    }

    private void RotateTowardsPlayer()
    {
        //1. Get direction from this object to the target
        Vector2 direction = (player.position - transform.position).normalized;

        // 2. Calculate the angle (in degrees) to face the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // 4. Apply rotation (instant or smooth)
        // Option A: Instant rotation (no smoothing)
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerB"))
        {
            // Handle collision with player (e.g., deal damage, play animation, etc.)
            takeDamage(10f);
        }
    }

    private void takeDamage(float damage)
    {
        // Handle taking damage (e.g., reduce health, play animation, etc.)
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        // Handle enemy death (e.g., play animation, disable controls, etc.)
        Debug.Log("Enemy has died.");
        // For example, you could disable the enemy GameObject:
        gameObject.SetActive(false);
    }
}