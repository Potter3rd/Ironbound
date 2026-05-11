using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMANAGER : MonoBehaviour
{
    public BladeData[] blades; // Array to hold references to BladeData ScriptableObjects
    public BladeData equipped;
    public SpriteRenderer playerSprite;

    private void Start()
    {
        offerBlade(blades[0]); // Equip the first blade by default
    }

    public void offerBlade(BladeData blade)
    {
        equipped = blade;
        playerSprite.sprite = null;
        playerSprite.sprite = equipped.bladeSprite;
        playerSprite.enabled = false;
        playerSprite.enabled = true;

        //Debug.Log("Equipped blade: " + equipped.bladeName + " with damage: " + equipped.damage);
        Debug.Log("Player sprite updated to: " + playerSprite.sprite.name);
    }
}
