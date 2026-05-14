using UnityEngine;
// This script controls the behavior of an enemy character in a 2D game. The enemy will detect the player, rotate to face them, and move towards them if they are within a certain range.
// //The enemy will also take damage from the player and die when its health reaches zero.

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public Player playerScript; // Reference to the Player script to access damage value
    public float damage = 20f; // Damage value that the enemy will deal to the player

    [SerializeField]
    public float speed = 3f;// Speed at which the enemy moves towards the player

    [SerializeField]
    public float detectionRange = 10f;// Range within which the enemy will detect and move towards the player

    [SerializeField]
    public float rotationSpeed = 200f; // Speed at which the enemy rotates to face the player

    [SerializeField]
    public Transform point; // Reference to the blade (assumed to be at player's position)

    [SerializeField]
    public float bladeRange = 3f; // Range within which the enemy will stop moving towards the player to avoid the blade

    [SerializeField]
    private Rigidbody2D rb;

    public float health = 50f; // Health value for the enemy



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //what methods get called in
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

    //spins to the player and moves towards them, but only if the blade is not too close. If the blade is too close, it will stop moving but still rotate to face the player.
    private void RotateTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    //moves towards the player if the blade is not too close
    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    //of the player touches the enemy, the enemy takes damage equal to the player's damage value. This assumes that the player's damage value is accessible through the playerScript reference.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerB"))
        {
            // Handle collision with player (e.g., deal damage, play animation, etc.)
            takeDamage(playerScript.getDamage());
        }
    }

    //takes damge from the player and checks for death
    private void takeDamage(float damage)
    {
        // Handle taking damage (e.g., reduce health, play animation, etc.)
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

    }

    //if the enemy runs out of health, this function is called to handle the enemy's death
    private void Die()
    {
        Debug.Log("Enemy has died.");
        FindObjectOfType<ChoiceUi>().ShowChoicePanel(playerScript);
        gameObject.SetActive(false);
    }

    public float GetHealth()
    {
        return health;
    }
}