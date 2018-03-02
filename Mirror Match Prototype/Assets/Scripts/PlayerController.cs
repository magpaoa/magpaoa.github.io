using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float accel, limit, decel, naturaldecel, jumpheight;
    public Rigidbody rb;
    public bool grounded;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {

        //moving right
        if (Input.GetAxis("Horizontal") > 0) 
        {
            rb.velocity += new Vector3 (accel, 0);

        }

        //Deceleration if past the speed limit
        if (rb.velocity.x > limit) 
        {
            rb.velocity += new Vector3(decel, 0);
        }

        //Deceleration that occurs naturally
        if(rb.velocity.x > 0 && Input.GetAxis("Horizontal") <= 0 && grounded) 
        {
            rb.velocity += new Vector3(-naturaldecel * Time.deltaTime, 0);
            if(rb.velocity.x - 1.0f <= 0) {
                rb.velocity = new Vector2(0, 0);
            }
        }

        //moving left
        if(Input.GetAxis("Horizontal") < 0) {
            rb.velocity -= new Vector3(accel, 0);

        }

        //Deceleration if past the speed limit
        if(rb.velocity.x < -limit) {
            rb.velocity -= new Vector3(decel, 0);
        }

        //Deceleration that occurs naturally
        if(rb.velocity.x < 0 && Input.GetAxis("Horizontal") >= 0  && grounded) {
            rb.velocity += new Vector3(naturaldecel * Time.deltaTime, 0 );
            if(rb.velocity.x + 1.0f >= 0) {
                rb.velocity = new Vector2(0, 0);
            }
        }

        //jump
        if(Input.GetButton("Jump") && grounded) 
        {
            rb.AddForce(transform.up * jumpheight);
            grounded = false;
        }


    }
}
