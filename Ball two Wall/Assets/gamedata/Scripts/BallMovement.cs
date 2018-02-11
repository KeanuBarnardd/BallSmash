using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{


    //Variables 
    public float ballSpeed = 10; //This will handle our Balls left and Right movement when swiped
    public float fallSpeed = 2;  //This will handle the speed at which our ball falls
    [HideInInspector]
    public bool hitWall = false; //Check if our ball has collided with a wall
    public bool moveRight, moveLeft;

    public RoundHandler roundHandler;


    private void OnEnable()
    {
        //Get our Components 
        roundHandler = FindObjectOfType<RoundHandler>();
    }

    #region functions 

    bool checkWhereToMove()
    {
        if (moveLeft)
        {
            transform.position -= transform.right * Time.deltaTime * ballSpeed;
            return true;
        }
        else if (moveRight)
        {
            transform.position += transform.right * Time.deltaTime * ballSpeed;
            return true;
        }
        return false;
    }


    public void moveDown() {
        fallSpeed = roundHandler.ballFallSpeed;

        if (!checkWhereToMove())
            transform.position -= transform.up * Time.deltaTime * fallSpeed;
    }

    #endregion
    public void Update()
    {
        moveDown();
    }

}
