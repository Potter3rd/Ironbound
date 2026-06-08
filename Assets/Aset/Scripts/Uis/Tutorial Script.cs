using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Manages the tutorial ui screen, allowing the player to close it by pressing the backspace key
public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial;

    void Start()
    {
        //so it always pops up on start
        tutorial.SetActive(true);
    }

    //if the player presses the backspace key, close the tutorial
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (tutorial.activeSelf)
            {
                CloseTutorial();
            }
        }
    }

    //Helper to turn the tutorial off
    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }
}
