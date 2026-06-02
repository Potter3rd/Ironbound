using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//for the main menu scene, when the play button is pressed, it will load the game scene
public class MainMenu : MonoBehaviour
{
    //loads the game secene wheht ebutton lpay is pressedS
    //no params
    //returns void
    //no exceptions
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
