using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //Variables
    public AudioSource aud;

    [Space]
    //Wall Collision Sounds 
    public AudioClip ballLose;
    public AudioClip ballCollision;
    //Interaction Sounds
    public AudioClip swipeSound;

    //Music 

    //Call the sound the we want to play
    public void PlaySound(AudioClip soundToPlay) {
        aud.PlayOneShot(soundToPlay);
    }

    private void Start()
    {
        //Get our Components 
        aud = GetComponent<AudioSource>();
    }

}
