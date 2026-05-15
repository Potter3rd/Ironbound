using UnityEngine;

// This script manages the settings menu, allowing the player to open and close it, as well as quit the game.
public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;

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
    }

    // Opens the settings menu and pauses the game
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Closes the settings menu and resumes the game
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Quits the game. If in the editor, it stops play mode. If in a build, it quits the application.
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
