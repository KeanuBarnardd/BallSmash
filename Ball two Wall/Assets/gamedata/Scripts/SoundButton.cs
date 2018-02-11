using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

    //Variables 
    public Sprite muteOff;
    public Sprite muteOn;
    public Button soundBut;
	
    public void muteSound(){
        
        //Turn our Sound on and Off when we press our Button
        AudioListener.pause = !AudioListener.pause;
        //If we are not muted and we press the MuteSound Button...
        if(soundBut.image.sprite == muteOff){
            //...then we will Mute it
            soundBut.image.sprite = muteOn;
        }else{
            //...else when we press it,itll be unmuted
            soundBut.image.sprite = muteOff;
        }
    }
}
