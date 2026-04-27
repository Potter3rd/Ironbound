using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void returnToGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void openMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
