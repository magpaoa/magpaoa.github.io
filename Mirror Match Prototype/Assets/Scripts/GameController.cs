using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public GameObject[] team1;
    public GameObject[] team2;

    private void Start() 
    {

        for (int i = 1; i < team1.Length; i++) 
        {
            TurnOffFunctionality(team1[i]);
        }

        for(int i = 0; i < team1.Length; i++) {
            TurnOffFunctionality(team2[i]);
        }
        TurnOnFunctionality(team1[0]);
        Debug.Log("check");
    }



    public void TurnOffFunctionality(GameObject something) 
    {
        something.GetComponent<PlayerController>().enabled = false;
//        something.GetComponentsInChildren<Launcher>();
    }

    public void TurnOnFunctionality(GameObject something)
    {
        something.GetComponent<PlayerController>().enabled = true;
    }
}
