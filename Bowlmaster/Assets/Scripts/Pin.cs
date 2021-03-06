﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public float standingThreshold=3f;
	public float distToRaise = 40f;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
        //print(name+IsStanding());
	}




    public bool IsStanding()
    {
        Vector3 rotationInEulers = transform.rotation.eulerAngles;
		float TiltInX = Mathf.Abs(270-rotationInEulers.x);
		float TiltInZ = Mathf.Abs(rotationInEulers.z);

        if(TiltInX < standingThreshold && TiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	public void RaiseIfStanding(){
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distToRaise, 0),Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
	}

	public void Lower()
	{
		rigidBody.useGravity = true;
		transform.Translate (new Vector3 (0, -distToRaise, 0),Space.World);
	}

}
