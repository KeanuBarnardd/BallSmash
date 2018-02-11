using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    //Variables
    public string levelWeWantToLoad;

    public Text txtHightScore;
    public Text txtScore;

    public void LoadOurLevel() {
        //This is the Scene we are going to load 
        SceneManager.LoadScene(levelWeWantToLoad);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        txtHightScore.text = ScoreManager.highScore.ToString();
        txtScore.text = ScoreManager.playerScore.ToString();
    }


    public void QuitApplication() {
        Application.Quit();
    }
}
