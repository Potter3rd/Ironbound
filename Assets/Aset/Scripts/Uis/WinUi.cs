using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//code to open the ui that shows u won if u call the boss health to 0 or less
public class WinUi : MonoBehaviour
{
    //reference to the win ui and the boss
    public GameObject winUI;
    public GameObject boss;

    // Start is called before the first frame update so that the win ui is not active at the start of the game
    void Start()
    {
        winUI.SetActive(false);
    }

    //checsk if the bosses health is lower than zero
     void Update()
    {
        if (boss.GetComponent<EnemyAi>().GetHealth() <= 0)
        {
            winUI.SetActive(true);
        }
    }
}
