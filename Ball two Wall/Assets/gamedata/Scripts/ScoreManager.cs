using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    //Variables 
    public static int highScore = 0;
    public static int playerScore = 1;
    public int roundCount;
    public Text scoreText;
    

    public void Start()
    {
        //When we begin our game we want the Score to start at 0 
        playerScore = PlayerPrefs.GetInt("PlayerScore",1);
        

        //Get our Highscore Variable, and there's no one, highScore has zero
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        //Display our high score for Testing 
        Debug.Log(PlayerPrefs.GetInt("Highscore").ToString());
    }

    private void FixedUpdate()
    {
        //Apply our Visuals to our Data
        scoreText.text = playerScore.ToString();

        //Check if our Old score is larger than our new score then set it to our new score if it is 
        if (playerScore > highScore)
        {
            //Set our new High Score to our player score
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

}
