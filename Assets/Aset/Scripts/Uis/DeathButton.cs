using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//loads the main menu when the player dies and clicks the button on the death screen
public class DeathButton : MonoBehaviour
{
    //when the button is lcicked it goes back to the main menu
    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }

}
