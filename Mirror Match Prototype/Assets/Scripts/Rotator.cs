using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float rotatespeed;

	// Update is called once per frame
	void Update () 
    {
        if(Input.GetAxis("Vertical") > 0) 
        {
            transform.RotateAround(transform.parent.transform.position, transform.parent.transform.forward, rotatespeed * Time.deltaTime);
        }

        if(Input.GetAxis("Vertical") < 0) {
            transform.RotateAround(transform.parent.transform.position, transform.parent.transform.forward, -rotatespeed * Time.deltaTime);
        }
    }
}
