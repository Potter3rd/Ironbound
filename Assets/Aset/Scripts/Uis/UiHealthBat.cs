using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthBat : MonoBehaviour
{
    //to start the slider for the health bar
    public Player Player;
    public Slider slider;
    public float currenthealth;

    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Start()
    {
        // Example of setting max health and current health
        SetMaxHealth((int)Player.health);
    }

    private void Update()
    {
        SetHealth((int)Player.health);
    }
}
