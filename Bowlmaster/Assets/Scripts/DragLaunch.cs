using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour
{
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Ball>();
    }
    public void MoveStart(float amount)
    {
        //Debug.Log(name + " moved by " + amount);
        if (!ball.inPlay)
        {
            float xPos=Mathf.Clamp(ball.transform.position.x + amount,-50f,50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }

    }
    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;
            float dragSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float dragSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(dragSpeedX, 0, dragSpeedZ);
            ball.Launch(launchVelocity);
        }

    }
}
    
        



    

