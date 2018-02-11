using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {
    
    //Variables
    public GameObject ballPrefab; //Our ball object that we want to spawn
    public ColourChanger colChangeHandle;


    public void SpawnBall() {
       
        //Spawn our object
        GameObject ball = (GameObject)Instantiate(ballPrefab,transform.position,transform.rotation);
        //Then we will Choose and set the colour of our new Ball
        PickBallColour(ball);
    }


    //Sets the color of the ball to be one of the two colours stored by the colour changer
    void PickBallColour(GameObject ball)
    {
        Color x = colChangeHandle.ReturnColorOneOrTwo();
        ball.GetComponent<SpriteRenderer>().color = x;
        
    }

}
