using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text highScoreText;

    public void loadLevel(string levelToLoad) {

        //When we press on our Button we want to load the Level
        SceneManager.LoadScene(levelToLoad);
       
    }

	public void Start(){

		ScoreManager.highScore = PlayerPrefs.GetInt("HighScore", 0);
		//PlayerPrefs.DeleteAll ();
	}
    public void Update()
    {
        //Update our Highscore so it is visible from the start 
		highScoreText.text = "" + ScoreManager.highScore;
    }

}
