using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour 
{
    public float[] xpos, zpos;
    float currentxpos, currentzpos;
    int currentelement;

    void Awake() 
    {
        xpos = new float[1];
        xpos[0] = 0;
        zpos = new float[1];
        zpos[0] = 0;

        GameObject start = GameObject.Find("Start(Clone)");
        this.transform.position = new Vector3(start.transform.position.x, 1, start.transform.position.z);
        currentxpos = this.transform.position.x;
        currentzpos = this.transform.position.z;
        currentelement = 1;
        addto(currentxpos, currentzpos);
    }
    
    void Update() 
    {
        if (this.transform.position.x >= currentxpos + 1.0f) 
        {
            currentxpos += 1.0f;
            addto(currentxpos, currentzpos);
        }
        if(this.transform.position.x <= currentxpos - 1.0f) 
        {
            currentxpos -= 1.0f;
            addto(currentxpos, currentzpos);
        }
        if(this.transform.position.z >= currentzpos + 1.0f) 
        {
            currentzpos += 1.0f;
            addto(currentxpos, currentzpos);
        }
        if(this.transform.position.z <= currentzpos - 1.0f) 
        {
            currentzpos -= 1.0f;
            addto(currentxpos, currentzpos);
        }
    }

    void addto(float x, float z) 
    {
        float[] tempx, tempz;
        tempx = new float[currentelement];
        tempz = new float[currentelement];

        xpos[currentelement - 1] = x;
        zpos[currentelement - 1] = z;

        for (int i = 0; i < currentelement; i++) 
        {
            tempx[i] = xpos[i];
            tempz[i] = zpos[i];
        }

        currentelement++;
        xpos = new float[currentelement];
        zpos = new float[currentelement];

        for(int i = 0; i < (currentelement - 1); i++) 
        {
            xpos[i] = tempx[i];
            zpos[i] = tempz[i];
        }

        Debug.Log("x is: " + x + " z is: " + z);
    }

    public float returnx(int element) 
    {
        return xpos[element];
    }

    public float returnz(int element) 
    {
        return zpos[element];
    }
}
