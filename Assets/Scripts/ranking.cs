using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ranking : MonoBehaviour
{
    //This code was for the player ranking, but I couldn't get it worked. I will leave it anyway so you can see my logic behind it.

    private GameObject[] runners;
    public GameObject destination;
    public GameObject player;

    public static float scoreValue = 0;
    public static float scoreValue1 = 0;
    public static float scoreValue2 = 0;
    public static float scoreValue3 = 0;
    public static float scoreValue4 = 0;

    public static float[] rankingArray = { scoreValue, scoreValue1, scoreValue2, scoreValue3, scoreValue4 };

    public Text rankingText;
    // Start is called before the first frame update

    private void Start()
    {
      
        runners = GameObject.FindGameObjectsWithTag("Runners");
        //Debug.Log(runners.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Array.Sort(rankingArray);


        if (rankingArray[0] == scoreValue)
        {
            rankingText.text = "Player Rank:5";
        }

        if (rankingArray[1] == scoreValue)
        {
            rankingText.text = "Player Rank:4";
        }

        if (rankingArray[2] == scoreValue)
        {
            rankingText.text = "Player Rank:3";
        }

        if (rankingArray[3] == scoreValue)
        {
            rankingText.text = "Player Rank:2";
        }

        if (rankingArray[4] == scoreValue)
        {
            rankingText.text = "Player Rank:1";
        }

    }

 
}
