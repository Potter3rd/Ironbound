using System;
using UnityEngine;

// This script manages the settings menu, allowing the player to open and close it, as well as quit the game.
public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject winUI;
    public AudioSource NormalM;
    public AudioSource PlayerM;


    public EnemyAi Boss;
    public AudioSource BossM;
    

    //watches if the user clicks escape and opens or closes the settings menu accordingly
    void Update()
    {
        // Press Escape to toggle settings
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
                CloseSettings();
            else
                OpenSettings();
        }

        //if the boss is dead open the winui screen
        if(Boss != null && Boss.health <= 0)
        {
            if (winUI != null)
            {
                winUI.SetActive(true);
                BossM.Stop();
                NormalM.Stop();
                if (!PlayerM.isPlaying)
                {
                    PlayerM.Play();
                }
                Debug.Log("playing player music");
            }
        }
    }

    // Opens the settings menu and pauses the game
    //no params
    //returns void
    //no exceptions
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Closes the settings menu and resumes the game
    //no params
    //returns void
    //no exceptions
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Quits the game. If in the editor, it stops play mode. If in a build, it quits the application.
    //no params
    //returns void
    //no exceptions
    public void QuitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
