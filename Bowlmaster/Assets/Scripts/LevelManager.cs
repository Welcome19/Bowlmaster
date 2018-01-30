using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public float autoLoadNextLevel;
    void Start()
    {
        if (autoLoadNextLevel != 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }
    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);    
    }
    public void QuitLevel()
    {
        Application.Quit();
    }
    public void LoadNextLevel()
    {
       Application.LoadLevel(Application.loadedLevel + 1); 
    }
   
}
