using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            deathScreen.SetActive(true);
        }
    }
}
