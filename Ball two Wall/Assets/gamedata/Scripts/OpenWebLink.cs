using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebLink : MonoBehaviour {

    //Input the Website we want to load 
    public string websiteUrl;

    public void loadUrl() {
        //Load our Website URL
        Application.OpenURL(websiteUrl);
    }
	
}
