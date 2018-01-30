using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private GameManager gameManager;
    private int lastStandingCount = -1;
    private bool BallOutOfPlay = false;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //print (CountStanding ());
        standingDisplay.text = CountStanding().ToString();
        if (BallOutOfPlay)
        {
            CheckStanding();
            standingDisplay.color = Color.white;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            BallOutOfPlay = true;
        }
    }

    void CheckStanding()
    {
        //Update the lastStandingCount
        //Call PinsHaveSettled() when actually setteled
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }

    }


    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        gameManager.Bowl(pinFall);

        //ActionMaster.Action action = actionMaster.Bowl(pinFall);
       // Debug.Log("pinfall: " + pinFall + " " + action);
        //ball.Reset();

        lastStandingCount = -1;
        BallOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }



}
