using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiltManager : MonoBehaviour
{
    public HiltData[] hilts; // Array to hold references to HiltData ScriptableObjects
    public HiltData equipped;
    public SpriteRenderer playerSprite;
    public Player player;

    private void Start()
    {
        offerHilt(hilts[0]); // Equip the first hilt by default
    }

    public void offerHilt(HiltData hilt)
    {
        equipped = hilt;
        playerSprite.sprite = equipped.hiltSprite;
        Debug.Log("Equipped hilt: " + equipped.hiltName + " with health: " + equipped.health);
        player.health = equipped.health; // Set player's health to the hilt's health
    }
}
