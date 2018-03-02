using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour {

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Update() {
        this.gameObject.transform.LookAt(GameObject.Find("playerPrefab(Clone)").transform.position);
        
    }
}
