using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
	public GameObject PinSet;
    public LevelManager levelManager;

    private PinCounter pinCounter;
	private ActionMasterOld actionMaster = new ActionMasterOld ();
	private Animator animator;
    

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();

    }
	
	// Update is called once per frame
	void Update () {

	}

	
	void OnTriggerExit(Collider collider)
	{
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.GetComponent<Pin> ()) {
			//print ("pin left");
			Destroy (thingLeft);
		}
	}

	public void RaisePins(){
		//raise standing pins only by distanceToRaise
		//Debug.Log("Raising Pins");
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding ();
           
		}
	}

	public void LowerPins(){
		//Debug.Log ("Lowering Pins");
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower ();
		}

	}
	public void RenewPins(){
		//Debug.Log ("Renewing Pins");
		Instantiate (PinSet,new Vector3(0,20,1829),Quaternion.identity);
	}

    public void PerformAction(ActionMasterOld.Action action) {
        if (action == ActionMasterOld.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMasterOld.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
          
        }
        else if (action == ActionMasterOld.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
            
        }
        else if (action == ActionMasterOld.Action.EndGame)
        {
            //throw new UnityException("Game ended");
            levelManager.LoadLevel("GameEnd");
        }
        //OR

        //string trigger=actionMaster.Bowl (pinFall).ToString();
        //animator.SetTrigger (trigger);
    }
}

