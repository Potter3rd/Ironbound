using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the player's blades, allowing them to equip different blades and update their sprite accordingly.
public class BladeMANAGER : MonoBehaviour
{
    public BladeData[] blades; // Array to hold references to BladeData ScriptableObjects
    public BladeData equipped; // Reference to the currently equipped blade
    public SpriteRenderer playerSprite; // Reference to the player's SpriteRenderer to update the sprite when a blade is equipped

    private void Start()
    {
        offerBlade(blades[0]); // Equip the first blade by default
    }

    // to equip a blade and update the player's sprite
    public void offerBlade(BladeData blade)
    {
        // Check if the blade is already equipped
        equipped = blade;

        // Update the player's sprite to match the equipped blade
        playerSprite.sprite = equipped.bladeSprite;

        //for debugging problems doesnt show the during actual game time
        Debug.Log(playerSprite.gameObject.name);
    }
}
