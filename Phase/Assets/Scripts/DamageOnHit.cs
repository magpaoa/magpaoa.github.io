using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<StatSystem>().changestat(StatSystem.statname.Health, -10);
    }
}
