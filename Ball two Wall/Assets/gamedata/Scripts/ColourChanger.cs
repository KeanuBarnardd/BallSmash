using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{

    //Variables
    public List<Color> Colours;


    public GameObject leftWall, rightWall;

    //Scripts
    public RoundHandler roundHandle;
    public SpawnHandler spawnHandle;

    [HideInInspector]
    public Color color_01;
    public Color color_02;
    public int lastColor_01Int = -1;
    public int lastColor_02Int = -1;
    public int assignBallCount = 0;

    // Use this for initialization
    void Start()
    {
        //Apply our scripts
        roundHandle = FindObjectOfType<RoundHandler>();
        spawnHandle = FindObjectOfType<SpawnHandler>();

    }

    /// <summary>
    /// Chooses two random colours from the Colours list and stores them as the two colours to apply to the balls this round. Calls a function that then applies those colours to
    /// the two walls
    /// </summary>
    public void AssignColourToBalls()
    {
        int i = Random.Range(0,Colours.Count - 1); //Chooses two random colours from the Colours list.
        int j = Random.Range(0, Colours.Count - 1);
        if (i == j) //If the two numbers are the same it just picks again
        {
            AssignColourToBalls();
        } else { 
            if (i == lastColor_01Int && j == lastColor_02Int) //Make sure that the two colours we have picked are not the same two colours on the walls already. Change this "&&" to "||" if you are happy for only 1 wall to need to change
            {
                AssignColourToBalls(); //walls are the same colour so choose again
            }
            else { // walls are not the same colour
                color_01 = Colours[i];
                color_02 = Colours[j];
                AssignColourToWalls(i, j); //Assign the two colours to the wall
                lastColor_01Int = i;
                lastColor_02Int = j;
            }
        }
    }

    /// <summary>
    /// Assign the two colours to the wall. NOTE that I set both the colour and the TINT color (You are free to remove the lines with .SetColor("_TintColor") is you dont want to set material tint - but your colours 
    /// could look odd).
    /// </summary>
    /// <param name="colorWall1">first wall colour </param>
    /// <param name="colorWall2">second wall colour</param>
    public void AssignColourToWalls(int colorWall1, int colorWall2)
    {
        leftWall.GetComponent<SpriteRenderer>().color = Colours[colorWall1];
        leftWall.GetComponent<SpriteRenderer>().material.SetColor("_TintColor", Colours[colorWall1]);
        rightWall.GetComponent<SpriteRenderer>().color = Colours[colorWall2];
        rightWall.GetComponent<SpriteRenderer>().material.SetColor("_TintColor", Colours[colorWall2]);
    }

    /// <summary>
    /// Returns either the first colour or the second colour we store. This is called when assigning colour to a ball. It will always return one of the two colours.
    /// </summary>
    /// <returns></returns>
    public Color ReturnColorOneOrTwo()
    {
        int randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {
            return color_01;
            
        }
        else {
            return color_02;
        }
    }
}
