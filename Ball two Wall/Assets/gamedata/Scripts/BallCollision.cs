using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollision : MonoBehaviour {

	//Access Scripts
	public ColourChanger colChanger;
	public SpawnHandler spawnHandler;
    public RoundHandler roundHandler;
    public fader fader;
    public SoundManager soundManager;
    public CameraControl camControl;

	public BallMovement ballMovement;
    public GameObject deathEffect;
 

	//One time use data
	public int colIndex; //Check which colour we have for Collision

	public void Start()
	{
		//Get our Components
		ballMovement = GetComponent<BallMovement>();
        
		//Get Scripts 
		colChanger = FindObjectOfType<ColourChanger>();
		spawnHandler = FindObjectOfType<SpawnHandler>();
        roundHandler = FindObjectOfType<RoundHandler>();
        fader = FindObjectOfType<fader>();
        soundManager = FindObjectOfType<SoundManager>();
        camControl = FindObjectOfType<CameraControl>();
	}

	void DestroyBall() {
        //Stop our ball from moving
        ballMovement.hitWall = true;
        ballMovement.ballSpeed = 0;

        //Create our Death Particle and set its colour to the colour of our ball
        GameObject deathEff = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        deathEff.GetComponent<ParticleSystem>().startColor = this.gameObject.GetComponent<SpriteRenderer>().color;
       
        Destroy(deathEff, 1f);
        Destroy(this.gameObject);
	}

	void CheckWallCollision(GameObject ballprefab, GameObject wall) {

		Color ballCol = ballprefab.GetComponent<SpriteRenderer>().color;
		Color wallCol = wall.GetComponent<SpriteRenderer>().color;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		//Collision with the Floor - Game over Step
		if (collision.tag == "Floor") {
            //Destroy our ball and cause the fail screen to Occur
            fader.wrongColour = true;
            //Play our sound if we get the wrong Colours !
            soundManager.PlaySound(soundManager.ballLose);
            camControl.Shake(0.2f, 10, 3);
        }

		//Check if we have Collided with either the left or Right wall, so we can process Colours
		if (collision.tag == "LeftWall" || collision.tag == "RightWall")
		{

			var wallSpriteRenderer = collision.GetComponent<SpriteRenderer>();
			var ballSpriteRenderer = GetComponent<SpriteRenderer>();

            //Compare both the colour of the Wall and Ball, and check if they match colours
			CheckColorMatching(ballSpriteRenderer, wallSpriteRenderer);

			DestroyBall();
		}
    }

	public void CheckColorMatching(SpriteRenderer first, SpriteRenderer second)
	{
        if (first.color == second.color)
        {
            //Change the Colour of our balls once we have reached out set score amount
            roundHandler.ChangeOurColour();
            //Add score and then Destroy our Object
            ScoreManager.playerScore++;
            //Play our Collision Sound When you gain a Point
            soundManager.PlaySound(soundManager.ballCollision);
            camControl.Shake(0.1f, 3, 2);

        }
        else
        {
            //If we get the wrong colour ,Switch Levels in Fader Script
            fader.wrongColour = true;
            //Play our sound if we get the wrong Colours !
            soundManager.PlaySound(soundManager.ballLose);
            //Play our Screen Shake
            camControl.Shake(0.2f, 10, 3);
        }		
	}

    public void FixedUpdate()
    {
        //If we get the wrong Colour then we want to fade out of the Game casuing us to lose, Causing all our balls to destroy
        if (fader.wrongColour == true) {
          
            DestroyBall();
        }
    }
}
