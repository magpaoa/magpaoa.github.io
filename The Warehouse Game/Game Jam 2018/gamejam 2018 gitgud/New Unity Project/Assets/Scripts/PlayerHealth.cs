using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float resetAfterDeathTime = 5f;
    public AudioClip deathclip;

    private Animator anim;
    private playerControl playerMovement;
    private HashIDs hash;
   // private SceneFadeInOut sceneFadeOut;
    private Vector3 lastPlayerSighting;
    private float timer;
    private bool playerDead;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<playerControl>();
        hash = GameObject.FindGameObjectWithTag("MainControl").GetComponent<HashIDs>();
        //sceneFadeOut = GameObject.FindGameObjectWithTag("fader").GetComponent<SceneFadeInOut>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("MainControl").GetComponent<EnemySight>().lastPlayerSighting;
    }


    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, true);
        AudioSource.PlayClipAtPoint(deathclip, transform.position);
    }

    

    void LevelReset()
    {
        timer += Time.deltaTime;

        if(timer >= resetAfterDeathTime)
        {
            //sceneFadeInOut.EndScene();
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(health == 0);
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
