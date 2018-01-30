using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {
    public Text finalScore;
    private void Start()
    {
        finalScore = GetComponent<Text>();
        finalScore.text = PlayerPrefs.GetInt("PlayerScore").ToString();
    }
   
   
}
