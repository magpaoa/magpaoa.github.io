using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //give player position
    Vector3 playerPosition;
    //place enemies in map
    public GameObject enemyPrefab;


    //place pursuer enemy on time zero
    public GameObject pursuerPrefab;

    //make regular enemy movement to play on discovery
    public float enemySpeed;

    //have pursuer "chase palyer"
    public float pursuerSpeed;

    //enemy placement should be random to some degree
    Vector3 enemyPosition;

    //add audio to ghost enemies in range of player
    public AudioSource ghostBabel;
    public AudioSource pursuerAudio;

	// Use this for initialization
	void Start ()
    {
        ghostBabel = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerPosition == enemyPosition)
        {
            ghostBabel = GetComponent<AudioSource>();

        }
        //pursuerAudio;
	}

    void PlaceEnemy(float z, float y)
    {
        
    }
}
