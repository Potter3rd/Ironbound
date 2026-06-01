using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Manages the tutorial, allowing the player to close it by pressing the enter key on the numpad
public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial;

    // Update is called once per frame
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

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }
}
