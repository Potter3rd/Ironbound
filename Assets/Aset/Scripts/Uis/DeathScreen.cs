using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when the player dies it ioens the death screen
public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        //if the player health is 0 or less it opens the death screen
        if (player.health <= 0)
        {
            deathScreen.SetActive(true);
        }
    }
}
