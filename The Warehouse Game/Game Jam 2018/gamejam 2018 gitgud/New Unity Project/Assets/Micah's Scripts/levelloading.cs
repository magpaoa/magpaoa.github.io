using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloading : MonoBehaviour {

    public void loadthislevel(int level) 
    {
        if(level == 1) 
        {
            GameObject.Find("scoreCanvas").GetComponent<ScoreTracker>().resetscore();
        }
        SceneManager.LoadScene(level);
    }

    public void exitgame() 
    {
        Application.Quit();
    }
}
