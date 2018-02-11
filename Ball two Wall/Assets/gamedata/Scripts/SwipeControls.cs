using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour {

    #region Backend 
    public float swipeMoveSpeed;
    private bool tap, swipeLeft, swipeRight;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    private bool moveLeft, moveRight = false;
    #endregion

    //Variables 
    public GameObject currentBall;

    //Scripts
    public FindClosestBall findClosestBall;
    public SoundManager soundManager;

    public void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        //Update which is the Ball we are going to move 
        currentBall = findClosestBall.lowestBall;

        //Reset Every fram - Anytime we have new frame make sure its false
        tap = swipeLeft = swipeRight = false;

        #region Standalone Inputs / Editor Input 
        //When you press on the Screen - It will register as a Tap
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            //Our start position is where our mouse is
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input 
        if (Input.touches.Length > 0)
        {
            //We are just pressing it on this frame
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            //If our touch has ended or been cancelled then we will reset our touch back to nothing
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate our Distance
        swipeDelta = Vector2.zero;
        //We have started our touch somewhere
        if (isDraging)
        {
            //We have found a swipe
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Did we cross the deadzone ?
        if (swipeDelta.magnitude > 100)
        {
            //Check which direction we are swiping in
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                {
                    if (currentBall != null) { //Make sure that our Ball exsists 
                        moveLeft = true;
                        currentBall.GetComponent<BallMovement>().moveLeft = true;
                        soundManager.PlaySound(soundManager.swipeSound);
                    }
                }
                else
                {
                    if (currentBall != null) {
                        moveRight = true;
                        currentBall.GetComponent<BallMovement>().moveRight = true;
                        soundManager.PlaySound(soundManager.swipeSound);
                    }         
                }
            }
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    //We can access from outsiude of you controls 
    public bool SwipeLeft { get { return SwipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
}
