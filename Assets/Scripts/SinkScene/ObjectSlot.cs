using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlot : MonoBehaviour {

    public bool occupied = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if(test != null)
        {
            test.pairedSlot = this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if (test != null && test.pairedSlot == this)
        {
            test.pairedSlot = null;
        }
    }
}
