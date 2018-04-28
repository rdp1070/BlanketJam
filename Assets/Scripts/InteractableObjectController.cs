using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class InteractableObjectController : MonoBehaviour {

    public Flowchart flowchart;

    // this should have a list of "dialouge options"

	// Use this for initialization
	void Start () {
        
	}
    
    // Update is called once per frame
    void Update () {
        
	}

    public void Display_Interaction_text(bool visible = true) {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Fired");
        flowchart.SetBooleanVariable("CollidingWithInteractable", true);
    }

    private void OnTriggerExit2D()
    {
        flowchart.SetBooleanVariable("CollidingWithInteractable", false);
    }

}
