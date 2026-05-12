using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManager : MonoBehaviour
{
    public GuardData[] guards; // Array to hold references to GuardData ScriptableObjects
    public GuardData equipped;
    public SpriteRenderer playerSprite;

    private void Start()
    {
        offerGuard(guards[0]); // Equip the first guard by default
    }

    public void offerGuard(GuardData guard)
    {
        equipped = guard;
        playerSprite.sprite = equipped.guardSprite;
    }
}
