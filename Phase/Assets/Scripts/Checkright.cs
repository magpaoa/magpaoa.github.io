using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkright : MonoBehaviour {


    void OnTriggerEnter2D() 
    {
        transform.parent.gameObject.GetComponent<PlayerController>().teleright = false;
        Debug.Log(transform.parent.gameObject.GetComponent<PlayerController>().teleright);
    }

    void OnTriggerExit2D() 
    {
        transform.parent.gameObject.GetComponent<PlayerController>().teleright = true;
        Debug.Log(transform.parent.gameObject.GetComponent<PlayerController>().teleright);
    }

}
