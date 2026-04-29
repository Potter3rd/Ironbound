using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player variables
    public float speed = 10.0f;
    private Rigidbody2D rb;
    public float health = 100.0f;
    public BladeMANAGER bladeManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, inputY * speed);
    }

    //Checks if the enemy touches the player and if it does, it takes damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyB"))
        {   
            EnemyAi enemy = other.GetComponentInParent<EnemyAi>();
            if (enemy != null)
            {
                TakeDamage(enemy.damage);
            }
        }
    }

    //take damage function that reduces the player's health and checks for death
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    //if player runs out of health, this function is called to handle the player's death
    private void Die()
    {
        // Handle player death (e.g., play animation, disable controls, etc.)
        Debug.Log("Player has died.");
        // For example, you could disable the player GameObject:
        gameObject.SetActive(false);
    }

    public float getDamage()
    {
        if (bladeManager.equipped != null)
        {
            return bladeManager.equipped.damage;
        }
        else
        {
            return 0.0f; // No blade equipped, so no damage
        }
    }
}