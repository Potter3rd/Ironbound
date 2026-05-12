using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WinUi : MonoBehaviour
{
    public GameObject winUI;
    public GameObject boss;

    void Start()
    {
        winUI.SetActive(false);
    }

     void Update()
    {
        if (boss.GetComponent<EnemyAi>().GetHealth() <= 0)
        {
            winUI.SetActive(true);
        }
    }
}
