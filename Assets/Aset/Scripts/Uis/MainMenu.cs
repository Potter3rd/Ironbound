using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//for the main menu scene, when the play button is pressed, it will load the game scene
public class MainMenu : MonoBehaviour
{
    //loads the loads the main game when the button to play is pressed
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
