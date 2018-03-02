using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGround : MonoBehaviour {

    void OnTriggerStay() 
    {
        transform.parent.gameObject.GetComponent<PlayerController>().grounded = true;
    }

    void OntriggerExit() 
    {
        transform.parent.gameObject.GetComponent<PlayerController>().grounded = false;
    }
}
