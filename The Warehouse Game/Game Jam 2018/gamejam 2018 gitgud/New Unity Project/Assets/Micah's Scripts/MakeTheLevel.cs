using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTheLevel : MonoBehaviour {

    public GameObject startarea;
    public GameObject endarea;
    public GameObject northsouthwall;
    public GameObject eastwestwall;
    public GameObject forklift;
    int maxwalls;

    private void Awake() 
    {
        Vector3 startareavector = new Vector3(Random.Range(0, 9), 0.5f, Random.Range(0, 9));
        Vector3 endareavector = new Vector3(Random.Range(0, 9), 0.5f, Random.Range(0, 9));
        
        Instantiate(startarea, startareavector, Quaternion.identity);

        while(startareavector.x == endareavector.x || startareavector.z == endareavector.z) 
        {
            endareavector = new Vector3(Random.Range(0, 9), 0.5f, Random.Range(0, 9));
        }

        Instantiate(endarea, endareavector, Quaternion.identity);

        Instantiate(forklift, new Vector3((Random.Range(0, 9) + .05f), 0.5f, (Random.Range(0, 9) + .05f)), Quaternion.identity);

        for(int x = 0; x < 9; x++) 
        {
            for(int y = 0; y < 9; y++) 
            {
                maxwalls = Random.Range(0, 2);


                if (x == 0 || x == 9) 
                {
                    maxwalls--;
                }
                if(y == 0 || y == 9) 
                {
                    maxwalls--;
                }

                Vector3 area = new Vector3(x, 1.0f, y);

                for(int i = maxwalls; i > 0; i--) 
                {
                    int wallside = Random.Range(1, 4);
                    
                    switch(wallside) 
                    {
                    case 1:
                        Instantiate(northsouthwall, new Vector3(area.x + 0.5f, area.y, area.z), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(northsouthwall, new Vector3(area.x - 0.5f, area.y, area.z), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(eastwestwall, new Vector3(area.x, area.y, area.z + 0.5f), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(eastwestwall, new Vector3(area.x, area.y, area.z - 0.5f), Quaternion.identity);
                        break;
                    default:
                        break;
                    }
                }
            }
        }
    }
    
}