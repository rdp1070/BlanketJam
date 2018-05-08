using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class InteractableObjectController : Clickable2D {

    public Flowchart flowchart;
    public string FungusMessage;
    public SpriteRenderer render;
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

        render.enabled = true;
        flowchart.SetBooleanVariable("CollidingWithInteractable", true);
        flowchart.SetStringVariable("InteractMessage", FungusMessage);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        render.enabled = false;
        flowchart.SetBooleanVariable("CollidingWithInteractable", false);
        flowchart.SetStringVariable("InteractMessage", "");
    }

}
