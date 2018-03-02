using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkleft : MonoBehaviour {

    void OnTriggerEnter2D() {
        transform.parent.gameObject.GetComponent<PlayerController>().teleleft = false;
    }

    void OnTriggerExit2D() {
        transform.parent.gameObject.GetComponent<PlayerController>().teleleft = true;
    }
}
