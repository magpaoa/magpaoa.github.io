using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaivor : MonoBehaviour {

    bool isactive, explode;
    public float delay;
    public int damage;

    void OnCollisionEnter() 
    {
        isactive = true;
        
    }
	
    void OnAwake() 
    {
        isactive = false;
        explode = false;
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
		if (isactive == true) 
        {
            delay -= Time.deltaTime;
            if (delay <= 0) 
            {
                detonate();
            }
        }
	}

    void detonate() 
    {
        explode = true;
        Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider other) 
    {
        if (isactive && explode) 
        {
            if (other.tag == "Player") 
            {
                other.transform.parent.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
        explode = false;
    }
}
