using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    
    //public int FinalScore;
    public Text[] rollTexts, FrameTexts;

    private void Start()
    {
        
    }
    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        for (int i = 0; i < scoreString.Length; i++)
        {
            rollTexts[i].text = scoreString[i].ToString();
        }

    }

    public void FillFrames(List<int> frames)
    {
        int i;
        for ( i = 0; i < frames.Count; i++)
        {
            FrameTexts[i].text = frames[i].ToString();
            if (frames.Count == 10)
            {
                //Debug.Log("current scoe is " + frames[i]);
                PlayerPrefs.SetInt("PlayerScore", frames[i]);
            }
        }
        
    }
    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;    // for box 1 to 21
            if(rolls[i]==0)
            {
                output += "-";
            }else if ((box % 2==0 || box==21) && rolls[i-1]+rolls[i]==10)     // for SPARE
            {
                output += "/";
            }else if(box>=19 && rolls[i]==10)
            {
                output += "X";
            }
            else if (rolls[i] == 10)  //for STRIKE
            {
                output += "X ";
            }
            else
            {
                output += rolls[i].ToString();
            }
            
        }
        return output;
    }
}
