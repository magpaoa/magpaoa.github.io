using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            Debug.Log("made it to the end");
            GameObject.Find("scoreCanvas").GetComponent<ScoreTracker>().addtoscore();
            SceneManager.LoadScene(1);
        }    
    }
}
