using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    //Variahles 
    public Camera mainCam;  //Access our Main Camera
    public float shake = 0; //This will be our Current Shake amount
    public float shakeAmount = 0.7f; //This will be our total Shake amount we can have
    public float decreaseFactor = 1.0f; //Handles at what rate our shake will decrease by 

    #region Functions
    
    public void ShakeScreen() {
        if (shake > 0)
        {
            mainCam.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else {
            shake = 0f;
        } 
    }

    #endregion

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) { ShakeScreen(); print("SS"); }
    }
}
