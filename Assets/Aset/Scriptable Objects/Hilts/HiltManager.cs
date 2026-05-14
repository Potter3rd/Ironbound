using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the player's hilts, allowing them to equip different hilts and update their sprite and health accordingly.
public class HiltManager : MonoBehaviour
{
    public HiltData[] hilts; // Array to hold references to HiltData ScriptableObjects
    public HiltData equipped; // Reference to the currently equipped hilt
    public SpriteRenderer playerSprite; // Reference to the player's SpriteRenderer to update the sprite when a hilt is equipped
    public Player player; // Reference to the Player script to update the player's health

    private void Start()
    {
        offerHilt(hilts[0]); // Equip the first hilt by default
    }

    public void offerHilt(HiltData hilt)
    {
        equipped = hilt; // Set the equipped hilt to the one offered
        playerSprite.sprite = equipped.hiltSprite; // Update the player's sprite to match the equipped hilt's sprite
        player.health = equipped.health; // Set player's health to the hilt's health so that different hilts can provide different health values and that the health bar updates accordingly
    }
}
