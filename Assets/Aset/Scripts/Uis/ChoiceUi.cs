using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script manages the UI for offering the player a choice of blades, hilts, or guards.
public class ChoiceUi : MonoBehaviour
{
    // UI
    public GameObject choicePanel;
    public Button[] choiceButtons;
    public Image[] choiceImages;
    public TextMeshProUGUI[] choiceNames;

    //Player
    public Player player;
    private BladeMANAGER bladeManager;
    private HiltManager hiltManager;
    private GuardManager guardManager;

    // Data for offered items
    private int[] offerTypes = new int[3];
    private object[] offeredItems = new object[3];

    void Start()
    {
        choicePanel.SetActive(false);
    }

    //opens the choice panel where the player can choose between 3 random items which are either a blade, hilt or guard.
    //randomly picks 3 random types of a hilt blade or guard and "listens to which button or part picked then sets the sprite and values to the item picked
    //param is the player game object which is used to access the blade, hilt, and guard managers to get the data for the offered items.
    public void ShowChoicePanel(Player player)
    {
        // Initialize player and managers
        bladeManager = player.GetComponent<BladeMANAGER>();
        hiltManager = player.GetComponent<HiltManager>();
        guardManager = player.GetComponent<GuardManager>();

        // Randomly select 3 unique types (0: Blade, 1: Hilt, 2: Guard)
        int[] types = { 0, 1, 2 };
        for (int i = types.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = types[i];
            types[i] = types[j];
            types[j] = temp;
        }

        // Offer the first 3 types from the shuffled array
        for (int i = 0; i < 3; i++)
        {
            offerTypes[i] = types[i];

            if (types[i] == 0) // Blades
            {
                BladeData blade = bladeManager.blades[Random.Range(0, bladeManager.blades.Length)];
                offeredItems[i] = blade;
                choiceImages[i].sprite = blade.bladeSprite;
                choiceNames[i].text = blade.bladeName + "\nDamage: " + blade.damage;
            }
            else if (types[i] == 1) // Hilts
            {
                HiltData hilt = hiltManager.hilts[Random.Range(0, hiltManager.hilts.Length)];
                offeredItems[i] = hilt;
                choiceImages[i].sprite = hilt.hiltSprite;
                choiceNames[i].text = hilt.hiltName + "\nHealth: " + hilt.health;
            }
            else // Guards
            {
                GuardData guard = guardManager.guards[Random.Range(0, guardManager.guards.Length)];
                offeredItems[i] = guard;
                choiceImages[i].sprite = guard.guardSprite;
                choiceNames[i].text = guard.guardName + "\nDefense: " + guard.defense;
            }

            // Sets up button listeners
            int index = i;
            choiceButtons[i].onClick.RemoveAllListeners();
            choiceButtons[i].onClick.AddListener(() => SelectItem(index));
        }

        choicePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // is called when the player selects an item from the choice panel.
    //it checks the type if item from the index which then uses the managers offered method wich updates the values needed and updates the sprite
    //param is an int of the index of the selected item in the offerTypes and offeredItems arrays.
    void SelectItem(int index)
    {
        Debug.Log("Selected Index: " + index);
        if (offerTypes[index] == 0)
        {
            bladeManager.offerBlade((BladeData)offeredItems[index]);
        }
        else if (offerTypes[index] == 1)
        {
            hiltManager.offerHilt((HiltData)offeredItems[index]);
        }
        else
        {
            guardManager.offerGuard((GuardData)offeredItems[index]);
        }


        choicePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}