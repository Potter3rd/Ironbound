using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//if the player is in a certian range of the boss it plays the music for the boss fight, if the player is out of range it stops the music
public class AudioForBoss : MonoBehaviour
{
    public AudioSource audioSource;

    //if the player enters the trigger area it plays the music for the boss fight
    //param is other or the other collider that entered the trigger area
    //no return
    //no exceptions
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    //if the player leaves the trigger area it stops the music for the boss fight
    //param is other or the other collider that entered the trigger area
    //no return
    //no exceptions
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
