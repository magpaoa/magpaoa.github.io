using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int playerhealth;

	// Use this for initialization
	void Start ()
    {
        playerhealth = 100;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //things die when they are killed
        if(playerhealth <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage) 
    {
        playerhealth -= damage;
    }
}
