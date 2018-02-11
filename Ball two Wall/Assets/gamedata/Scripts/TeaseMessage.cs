using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaseMessage : MonoBehaviour {

    //The list of Quotes we can change and Input into the Message
    public string[] loseMessages;
    

    //The Text that we want to change our LoseMessage to
    public Text messageTextObj;

    public void Start()
    {
        //Get a random message from our LoseMessages 
        string displayMessage = loseMessages[Random.Range(0, loseMessages.Length)];

        //Update our Text Object to display our Message
        messageTextObj.text = displayMessage;
    }
}
