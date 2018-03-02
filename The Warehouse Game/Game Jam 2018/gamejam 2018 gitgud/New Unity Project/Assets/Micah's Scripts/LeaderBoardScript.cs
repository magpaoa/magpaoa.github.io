using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour {

    [System.Serializable]
    public class topscorer {

        public string[] name;

        public int[] score;

        public topscorer() {
            name = new string[10];
            score = new int[10];
        }
    }

    public string[] leadername;
    public int[] leaderscore;

    public Text[] nametext, scoretext;

    public GameObject inputcanvas;
    public GameObject displaycanvas;
    bool highscore;
    public int currentscore;
    public Text placementtext;
    int place;
    public Text enteredname;

    private void Awake() {
        
        if(GameObject.Find("scoreCanvas").GetComponent<ScoreTracker>().currentscore > 0) {
            currentscore = GameObject.Find("scoreCanvas").GetComponent<ScoreTracker>().currentscore;
        } else {
            currentscore = 0;
        }

        Debug.Log("awake?");

        highscore = false;
        leadername = new string[10];
        leaderscore = new int[10];
        load();
        inputcanvas.SetActive(false);
        displaycanvas.SetActive(false);


        for(int i = 0; i <= 9; i++) {
            if(currentscore > leaderscore[i] && highscore == false) {
                highscore = true;
                inputcanvas.SetActive(true);
                placementtext.text = (i + 1).ToString();
                place = i;
            }
        }

        if(!highscore) {
            displaycanvas.SetActive(true);
        }
    }

    public void savebutton()
        {
        save(place, enteredname.text, currentscore);
        displaycanvas.SetActive(true);
        inputcanvas.SetActive(false);
        }

    public void save(int place, string playername, int score) 
    {
        Debug.Log("game saved");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/leaderboard.dat");

        topscorer player = new topscorer();

        for(int i = 9; i > place; i--) 
        {
            leadername[i] = leadername[i - 1];
            leaderscore[i] = leaderscore[i - 1];
        }

        for(int i = 0; i < 9; i++) 
        {
            player.name[i] = leadername[i];
            player.score[i] = leaderscore[i];
        }

        player.name[place] = playername;
        player.score[place] = score;

        bf.Serialize(file, player);
        file.Close();

        load();
    }

    public void load() 
    {
        if(File.Exists(Application.persistentDataPath + "/leaderboard.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/leaderboard.dat", FileMode.Open);
            topscorer currentboard = (topscorer)bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < 10; i++) 
            {
                leadername[i] = currentboard.name[i];
                leaderscore[i] = currentboard.score[i];

                if(leadername[i] == null) {
                    nametext[i].text = "null";
                } else {
                    nametext[i].text = leadername[i];
                }
                scoretext[i].text = leaderscore[i].ToString();
            }

        }
    }
}
