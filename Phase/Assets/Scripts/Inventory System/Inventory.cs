using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [System.Serializable]
    public class Item 
    {
        public ItemDefinition definition;
        public int currentamount;
    }

    [SerializeField]
    List<Item> currentinventory;
	// Use this for initialization
	void Start () 
    {
        valuemodifier(currentinventory[0].definition.affectedvariable, currentinventory[0].definition.relativepower, currentinventory[0].currentamount);
        valuemodifier(currentinventory[1].definition.affectedvariable, currentinventory[1].definition.relativepower, currentinventory[1].currentamount);
        valuemodifier(currentinventory[2].definition.affectedvariable, currentinventory[2].definition.relativepower, currentinventory[2].currentamount);
    }   

    void updateall() 
    {
        //for(int i = 0; i < currentinventory.Length; i++) 
        //{
        //        valuemodifier(currentinventory[i].definition.affectedvariable, currentinventory[i].definition.relativepower, currentinventory[i].currentamount);
        //}
    }

    void valuemodifier(string modvar, float modvalue, int numberoftimes) 
    {
        for(int i = 0; i < numberoftimes; i++) {
            modvalue *= modvalue;
        }
        switch(modvar) 
        {
        case "jumpheight":
            transform.gameObject.GetComponent<PlayerController>().jumpheight += transform.gameObject.GetComponent<PlayerController>().basejumpheight * modvalue - transform.gameObject.GetComponent<PlayerController>().basejumpheight;
            break;
        case "maxspeed":
                transform.gameObject.GetComponent<PlayerController>().limit += transform.gameObject.GetComponent<PlayerController>().baselimit * modvalue - transform.gameObject.GetComponent<PlayerController>().baselimit;
            break;
        case "acceleration":
                transform.gameObject.GetComponent<PlayerController>().accel += transform.gameObject.GetComponent<PlayerController>().baseaccel * modvalue - transform.gameObject.GetComponent<PlayerController>().baseaccel;
            break;
        default:
            break;
        }
    }

    //void RemoveItem(Item anitem) 
    //{
    //    anitem.currentamount--;
    //    if(anitem.currentamount <= 0) 
    //    {
    //        currentinventory.amount = 0;
    //    }
    //}
}