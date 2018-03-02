using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemScript : MonoBehaviour {
    public Inventory.Item thisitem;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") 
        {
            //need some code to update inventory
            Destroy(this.gameObject);
        }
    }
}
