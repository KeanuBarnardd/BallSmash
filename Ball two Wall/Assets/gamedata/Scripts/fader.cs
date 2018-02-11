using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fader : MonoBehaviour {

    //Variables 
    public float fadeSpeed = 1.5f;     //Speed that the screen fades to and from black
    private bool sceneStarting = true; //Wehter or not the SCreen is still fading in
    public string levelToLoad;         //This is the level we are going to load next

    public bool wrongColour = false;

    #region functions
    public void FadeToClear() {
        //Lerp the Colour of the texture between itself and transparent
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    public IEnumerator FadeToBlack() {
        yield return new WaitForSeconds(1f);
        //Lerp the colour of the textyre between itself and transparent
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
    }

    public void StartScene() {
        //Fade the Texture to clear - so we can see our game Screen
        FadeToClear();

        //if the texture is almost clear..
        if (GetComponent<GUITexture>().color.a <= 0.5f) {
            //...Set the colour to clear and disable the Texture
            GetComponent<GUITexture>().color = Color.clear;
            GetComponent<GUITexture>().enabled = false;

            //The scene is no longer starting 
            sceneStarting = false;
        }
    }

    public void LoseDecals() {

        //Load the Lose Screen
        SceneManager.LoadScene(levelToLoad);
    }

    public void EndScene() {
        
        if (wrongColour == true) {
            //Make sure the texture is enabled 
            GetComponent<GUITexture>().enabled = true;

            //Start fading towards Black 
            StartCoroutine(FadeToBlack());
            //if the screen is almost black...
            if (GetComponent<GUITexture>().color.a >= 0.95f)
            {
                LoseDecals();
            }
        }
    
    }
    #endregion

    public void Awake()
    {

        //Set the texture so that it is the size of the screen and covers it
        GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);  
    }

    public void Start()
    {
        StartScene();
    }

    public void FixedUpdate()
    {
        EndScene();
    }
}
