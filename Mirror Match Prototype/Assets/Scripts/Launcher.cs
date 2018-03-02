using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour {
    public float launchforce;
    public Slider powerslider;
    public GameObject projectileprefab;
    public bool canshoot;

    private void Awake() 
    {
        canshoot = true;
    }

    private void Update() 
    {
        if (Input.GetButton("Fire2") && canshoot) 
        {
            launchforce = powerslider.value;
            GameObject projectile = Instantiate(projectileprefab, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(transform.up * launchforce);
            canshoot = false;
        }
    }
}