using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerScript : MonoBehaviour {

    int currentposition;
    public GameObject player;
    public float movespeed;
    bool dothisonce;
    float delay;

    private void Awake() 
    {
        dothisonce = true;
        currentposition = 0;
        player = GameObject.Find("playerPrefab(Clone)");
        this.gameObject.transform.position = new Vector3(player.GetComponent<PlayerTracker>().returnx(currentposition), 
            1.0f, 
            player.GetComponent<PlayerTracker>().returnz(currentposition));
        currentposition++;
    }

    void Update () 
    {
        Debug.Log(currentposition);

        movetowardstarget(player.GetComponent<PlayerTracker>().returnx(currentposition), player.GetComponent<PlayerTracker>().returnz(currentposition));
	}

    void movetowardstarget(float x, float z) 
    {
        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, 1.0f, z), movespeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, new Vector3(x, 1.0f, z)) <= 0.1f && dothisonce) 
        {
            currentposition++;
            dothisonce = false;
            delay = 1;
        }

        if(dothisonce == false) 
        {
            
            delay -= Time.deltaTime;
            if(delay <= 0) 
            {
                dothisonce = true;
            }

        }
    }
}
