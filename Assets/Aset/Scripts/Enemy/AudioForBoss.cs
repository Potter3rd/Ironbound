using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//if the player is in a certian range of the boss it plays the music for the boss fight, if the player is out of range it stops the music
public class AudioForBoss : MonoBehaviour
{
    //variables for the audio source, range, and player transform
    public AudioSource audioSource;
    public float range = 15f;
    public Transform player;

    public AudioSource normal;

    //if the player enters the with the specified range it plays the music for the boss fight
    //param is other or the other collider that entered the trigger area
    //no return
    //no exceptions
    private void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < range)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                normal.Stop();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                normal.Play();
            }
        }
    }
}
