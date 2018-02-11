using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundHandler : MonoBehaviour
{
    #region previousCode
    //Variables
    //[Tooltip("When we spawn the Ball ( 1 Round = 1 Ball ) ")]
    //public int spawnRound;   //Spawn a ball every round
    //[Tooltip("Switch our colours at this amount of Ball spawns")]
    //public int roundSwitchMax = 20; //Max amount of rounds before colour switch
    //[Tooltip("Spawn time in between each ball spawn , Smaller the number faster the spawn")]
    //public float Spawntimer; //1 rotation of the timer = 1 round, decrease it and it will increase difficulty
    //[Tooltip("Increase the amount to speed up the spawn rate between each ball")]
    //private float takeAwayAmount = 0.02f; //This will be what we take away from our Timer each round


    //public bool temppause;
    //[Tooltip("How long we will pause before starting the next wave")]
    //public float pauseTimer;

    //private float resetTimer;
    //public int roundReset;

    ////Scripts  
    //public SpawnHandler spawnHandle;
    //public ColourChanger colChange;

    //// Use this for initialization
    //void Start()
    //{
    //    //Set our Variables 
    //    resetTimer = Spawntimer;
    //    roundReset = spawnRound;
    //    colChange.AssignColourToBalls();
    //}

    ///// <summary>
    ///// Stops the balls falling. Then calls the function that changes ball colour
    ///// </summary>
    ///// <returns></returns>
    //IEnumerator TemporarilyPause()
    //{
    //    temppause = true;
    //    yield return new WaitForSeconds(pauseTimer);
    //    spawnRound = roundReset;
    //    colChange.AssignColourToBalls();
    //    temppause = false;
    //}


    //// Update is called once per frame
    //void FixedUpdate()
    //{ //I changed this to be FIXEDUPDATE instead of UPDATE, as if it was UPDATE, balls would fall faster/slower on different devices. FixedUpdate is constant.

    //    Spawntimer -= Time.deltaTime; // Take time from timer 
    //    // Check our timer to see
    //    if (Spawntimer <= 0)
    //    {
    //        /*  if (!temppause) *///If it is paused, dont spawn as we are waiting for balls to fall off teh screen before changing colour
    //        spawnHandle.SpawnBall();

    //        Spawntimer = resetTimer;

    //        //If the round is at our Round Colour Switch amount then reset our round to 0
    //        if (spawnRound >= roundSwitchMax)
    //        {
    //            //if (!temppause)
    //            //StartCoroutine(TemporarilyPause());
    //            //Decrease our Round Speed amount  
    //            //if (ScoreManager.playerScore % 20 == 0) {
    //            //    spawnRound = roundReset;
    //            //    print("We are changing the colour ");
    //            //    colChange.AssignColourToBalls();
    //            //}
    //            print("We are changing the colour ");
    //            //colChange.AssignColourToBalls();
    //        }
    //        else
    //        {
    //            spawnRound++;
    //        }
    //    }
    //}
    #endregion

    [Header("Spawning Variables")]
    public float spawnTimeBetweenBalls;    //The time between each Ball Instantiation

    private int ballSpawnCount;             //Amount of Balls we have spawned so far..
    public int colourSwitchRound;          //Which round we will change the Colour of our Balls and Walls

    public float increaseBallSpeedIncrement; //This will handle which how much our ball speed will be multiplied by
    public float ballFallSpeed;   //This will hold how much we have tallied and will be our multiplied by
    public float maxFallSpeed;   //This will be the fastest our ball can fall (Sets the Limit)
    public SpawnHandler spawnHandle;
    public ColourChanger colChange;

    public void Start()
    {
        //Get our Components
        spawnHandle = FindObjectOfType<SpawnHandler>();
        colChange = FindObjectOfType<ColourChanger>();

        //Apply our Colour to our Balls
        colChange.AssignColourToBalls();

        //Spawn our initial wave of Balls
        StartCoroutine(spawnBallWave(spawnTimeBetweenBalls, colourSwitchRound));
    }
    #region Functions


    IEnumerator spawnBallWave(float spawnTime, int waveSize)
    {

        //Check if the amount of balls spawned is less than our wave amount - keep spawning until false
        for (int i = 0; i < waveSize; i++)
        {
            //Add to the amount of Ball spawned in, so we can in turn change colours
            ballSpawnCount++;
            //Access our spawn handler so that we can create our balls and set colour
            spawnHandle.SpawnBall();
            //Wait our spawnTime before spawning our next ball , in a wave.
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void ChangeOurColour() {

        //Check if we have gained points equal to our ColourSwitchRound amount then we will change the Colour of our Walls/Balls
        if (ScoreManager.playerScore % colourSwitchRound == 0 && ScoreManager.playerScore != 0)
        {
            //Then we will change the Colour of our balls...
            //Check if we CAN switch our Colour, then switch it, once we have switched our colour make sure that we cant switch it in the same round
            colChange.AssignColourToBalls();

            //Reset it back to 0
            ballSpawnCount = 0;

            //Check if our speed and make sure we dont set it too fast!
            if (ballFallSpeed < maxFallSpeed)
            {
                //Apply our Increase on our BallsIncrement so that we can increase our speed
                ballFallSpeed += increaseBallSpeedIncrement;
            }
            else { ballFallSpeed = maxFallSpeed; }
       
            //Spawn our wave of balls
            StartCoroutine(spawnBallWave(spawnTimeBetweenBalls, colourSwitchRound));
        }
    }

    #endregion
}
