using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float accel, limit, decel, naturaldecel, jumpheight, crouchaccel, crouchlimit, teleportdistance, delay;
    public float baseaccel, baselimit, basedecel, basejumpheight;
    public Rigidbody2D rb;
    public GameObject worlditem;
    public bool grounded;
    public bool teleright, teleleft;
    public int currentitem;
    Vector3 startingscale;



    void Start() 
    {
        currentitem = 0;
        rb = GetComponent<Rigidbody2D>();
        startingscale = this.gameObject.transform.localScale;
        delay = 0;
        teleright = true;
        teleleft = true;
        baseaccel = accel;
        baselimit = limit;
        basedecel = decel;
        basejumpheight = jumpheight;
        GetComponent<StatSystem>().addcallbackfunction(StatSystem.statname.Health, onhealthchange);
    }

    public void onhealthchange(float amountchanged) 
    {
        Debug.Log("player health has changed to " + amountchanged);

    }

    private void FixedUpdate() 
    {
        if(Input.GetAxis("Vertical") < 0 && transform.localScale.y > 1)
        {
            transform.localScale -= new Vector3(0, 0.1f, 0);
            accel -= crouchaccel * Time.deltaTime;
            limit -= crouchlimit * Time.deltaTime;
            decel -= crouchaccel * Time.deltaTime;
        } else if(Input.GetAxis("Vertical") >= 0 && transform.localScale.y < 2) 
        {
            transform.localScale += new Vector3(0, 0.1f, 0);
            accel += crouchaccel * Time.deltaTime;
            limit += crouchlimit * Time.deltaTime;
            decel += crouchaccel * Time.deltaTime;
        }


        //moving right
        if (Input.GetAxis("Horizontal") > 0) 
        {
            rb.velocity += new Vector2 (accel, 0);

        }

        //Deceleration if past the speed limit
        if (rb.velocity.x > limit) 
        {
            rb.velocity += new Vector2(decel, 0);
        }

        //Deceleration that occurs naturally
        if(rb.velocity.x > 0 && Input.GetAxis("Horizontal") <= 0 && grounded) 
        {
            rb.velocity += new Vector2(-naturaldecel * Time.deltaTime, 0);
            if(rb.velocity.x - 1.0f <= 0) {
                rb.velocity = new Vector2(0, 0);
            }
        }

        //moving left
        if(Input.GetAxis("Horizontal") < 0) {
            rb.velocity -= new Vector2(accel, 0);

        }

        //Deceleration if past the speed limit
        if(rb.velocity.x < -limit) {
            rb.velocity -= new Vector2(decel, 0);
        }

        //Deceleration that occurs naturally
        if(rb.velocity.x < 0 && Input.GetAxis("Horizontal") >= 0  && grounded) {
            rb.velocity += new Vector2(naturaldecel * Time.deltaTime, 0 );
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

        //shortteleport
        if (Input.GetButton("Fire1") && delay > 3) 
        {
            Debug.Log("call");
            if(Input.GetAxis("Horizontal") >= 0 && teleright) 
            {
                this.gameObject.transform.position += new Vector3(teleportdistance, 0, 0);
            } 
            else if (Input.GetAxis("Horizontal") < 0 && teleleft) 
            {
                this.gameObject.transform.position -= new Vector3(teleportdistance, 0, 0);
            }
            delay = 0;
        }
        delay += Time.deltaTime;

        if(Input.GetButton("Fire2"))
        {
            dropitem(currentitem);
        }
    }

    void dropitem(int itemslot) 
    {
        GameObject createditem = Instantiate(worlditem, transform.position, Quaternion.identity);
        //createritem.GetComponent<WorldItemScript>().thisitem = this.gameObject.GetComponent<Inventory>().currentinventory[itemslot];
    }
}