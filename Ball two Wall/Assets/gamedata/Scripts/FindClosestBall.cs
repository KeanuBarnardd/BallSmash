using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestBall : MonoBehaviour
{

    public GameObject lowestBall;

    //Variables
    public float xpos;

    public void FixedUpdate()
    {
        FindLowestBall();
    }

    public void FindLowestBall()
    {
        //Find our Balls and put them into our array
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        float lowestBallPosition = 99999f; //Something our balls will never be lager than


        //Go through our balls in our Array
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i].transform.position.x == xpos) {
                //Get our balls Y position...
                float thisY = balls[i].transform.position.y;
                //Check if it is less than our LOWEST ball position
                if (thisY < lowestBallPosition)
                {
                    //Set our lowest ball to thisY (Current Ball)
                    lowestBallPosition = thisY;
                    //Update our Game Object to be the ball to us
                    lowestBall = balls[i];
                }
            }     
        }
    }
}
