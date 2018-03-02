using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public Vector3 playerPosition;
    public GameObject playerPrefab;
    private Rigidbody rb;
    public AudioSource playerSteps;
    public AudioSource playerVoice;
    GameObject player;

    public int playerSpeed;

    // Use this for initialization
    void Start ()
    {
        player = Instantiate(playerPrefab);
        rb = GetComponent<Rigidbody>();
        playerVoice = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        //allows for update on player movement and keeps a log in Unity
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 1.0f;

        if(Input.GetAxis("Horizontal") == 0) {
            player.transform.Rotate(0, 0, 0);
        }
        player.transform.Rotate(0, x, 0);
        player.transform.Translate(0, 0, z);
        playerSteps = GetComponent<AudioSource>();
    }


}
