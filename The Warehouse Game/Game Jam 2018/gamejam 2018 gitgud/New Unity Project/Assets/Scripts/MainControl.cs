using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    public GameObject followerenemy;
    //timer
    public float timeRemaining;
    //audio que for time up-main pursuerspawn
    public AudioSource pursuerSpawn;
    //text for time display - will change for asthetic
    //from text to visual bar
    public Text timerText;
    bool stalker;

    public AudioSource BGM;
    public float starttimer;
    // Use this for initialization
    void Awake()
    {
        stalker = true;
        BGM = GetComponent<AudioSource>();
        timerText.text = "Time Remaining: " + timeRemaining;
        timeRemaining = starttimer;
    }

    // Update is called once per frame
    void Update()
    {



        if (timeRemaining <= 0)
        {
            SendMessageUpwards("Metal Grinds and Pirces Your Ears");
            pursuerSpawn = GetComponent<AudioSource>();
            timerText.text = "It's Coming!";
            if(stalker)
            {
                Instantiate(followerenemy);
                stalker = false;
            }
        } else {
            timerText.text = "Time Remaining: " + timeRemaining;

            timeRemaining -= Time.deltaTime;
        }
       

    }


}
