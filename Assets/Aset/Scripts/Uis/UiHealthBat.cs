using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the health bar on the UI, it gets the current health of the player and updates the slider accordingly
public class UiHealthBat : MonoBehaviour
{
    //to start the slider for the health bar
    public Player Player;
    public Slider slider;
    public float currenthealth;

    //sets the max health of the slider to the player's max health and sets the current health to the player's current max health
    //param is an int of the players health
    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //sets the current health of the slider to the player's current health
    //param is an int of the players health
    private void SetHealth(int health)
    {
        slider.value = health;
    }

    // Start is called before the first frame update, it sets the max health and current health of the slider to the player's max health and current health
    private void Start()
    {
        // Example of setting max health and current health
        SetMaxHealth((int)Player.health);
    }

    // Update is called once per frame, it updates the current health of the slider to the player's current health
    private void Update()
    {
        SetHealth((int)Player.health);
    }
}
