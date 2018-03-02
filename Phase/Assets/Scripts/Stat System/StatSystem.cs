using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour {

    public enum statname 
    {
        Health,
        Jumpheight,
        Maxspeed,
        Acceleration
    }

    public delegate void statchangecallback(float newvalue);

    [System.Serializable]
    public class Stat
    {
        public statname name;
        public float initialvalue;
        public float currentvalue;
        public statchangecallback callbackfunction;
    }

    public List<Stat> stats;
    Dictionary<statname, Stat> statcollection = new Dictionary<statname, Stat>();

    void Awake() 
    {
        foreach(Stat s in stats) 
        {
            statcollection[s.name] = s;
        }

        foreach(Stat s in stats) 
        {
            initializestat(s.name);
        }
    }

    public void changestat(statname stat, float modamount) 
    {
        statcollection[stat].currentvalue += modamount;

        statcollection[stat].callbackfunction(statcollection[stat].currentvalue);
    }

    public void initializestat(statname stat) 
    {
        statcollection[stat].currentvalue = statcollection[stat].initialvalue;
    }

    public float getstat(statname stat) 
    {
        return statcollection[stat].currentvalue;
    }

    public void addcallbackfunction(statname stat, statchangecallback function) 
    {
        statcollection[stat].callbackfunction += function;
    }
}