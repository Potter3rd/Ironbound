using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script manages the player's Guards, allowing them to equip different guards and update their sprite accordingly.

public class GuardManager : MonoBehaviour
{
    public GuardData[] guards; // Array to hold references to GuardData ScriptableObjects
    public GuardData equipped; // Reference to the currently equipped guard     
    public SpriteRenderer playerSprite; // Reference to the player's SpriteRenderer to update the sprite when a guard is equipped

    private void Start()
    {
        offerGuard(guards[0]); // Equip the first guard by default
    }

    public void offerGuard(GuardData guard)
    {
        equipped = guard; // Set the equipped guard to the one passed as a parameter
        playerSprite.sprite = equipped.guardSprite; // Update the player's sprite to match the equipped guard's sprite
    }
}
