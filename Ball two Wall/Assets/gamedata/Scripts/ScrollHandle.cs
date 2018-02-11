using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHandle : MonoBehaviour {

    public float speed = 0;

	// Update is called once per frame
	void Update () {
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, Time.time * speed);
	}
}
