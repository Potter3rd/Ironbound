using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMANAGER : MonoBehaviour
{
    public BladeData[] blades; // Array to hold references to BladeData ScriptableObjects
    public BladeData equipped;
    public SpriteRenderer playerSprite;

    public void offerBlade(BladeData blade)
    {
        equipped = blade;
        playerSprite.sprite = equipped.bladeSprite;
        Debug.Log("Equipped blade: " + equipped.bladeName + " with damage: " + equipped.damage);
    }
}
