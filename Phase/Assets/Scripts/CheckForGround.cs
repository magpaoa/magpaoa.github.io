using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGround : MonoBehaviour {

    void OnTriggerEnter2D() 
    {
        transform.parent.gameObject.GetComponent<PlayerController>().grounded = true;
    }

    void OntriggerExit2D() 
    {
        transform.parent.gameObject.GetComponent<PlayerController>().grounded = false;
    }
}
