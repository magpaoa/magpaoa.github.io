using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public int currentscore;
    public Text scoretext;
    public static ScoreTracker scorekeeper;
    void Awake() 
    {
        if(scorekeeper == null) 
        {
            currentscore = 0;
            DontDestroyOnLoad(this.gameObject);
            scorekeeper = this;
        } else {
            Destroy(this.gameObject);
        }

    }
   
    void Update() 
    {
        scoretext.text = "Current Score is: " + currentscore;
    }

    public void addtoscore() 
    {
        currentscore++;
    }

    public void resetscore() 
    {
        currentscore = 0;
    }
}
