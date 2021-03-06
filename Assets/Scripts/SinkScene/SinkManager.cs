﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkManager : MonoBehaviour {

    public List<GameObject> cabinetSlot = new List<GameObject>();
    public HingeJoint2D cursorJoint;
    public ClickableObject activeObject;
    public int numObjects;
    public int obstructions;
    public int placedObjects;
    public bool positiveAction;
    public float minHeight;
    public float maxHeight;
    bool objectHeld;
    protected Vector3 worldPoint = Vector3.zero;
    public Fungus.Flowchart flowChart;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
           
        worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        worldPoint.z = 0;
        worldPoint.y = Mathf.Clamp(worldPoint.y, minHeight, maxHeight);
        cursorJoint.gameObject.transform.position = worldPoint;
        

		if(Input.GetMouseButtonDown(0))
        {
            TryPickupObject();
        }
        else if (Input.GetMouseButtonUp(0) && activeObject != null)
        {
            ReleaseObject();
        }
    }

    public void TryPickupObject()
    {
        activeObject = null;
        worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        worldPoint.y = Mathf.Clamp(worldPoint.y, minHeight, maxHeight);
        RaycastHit2D[] hits = Physics2D.RaycastAll(worldPoint, Vector2.down, 0.1f, LayerMask.GetMask("ClickableItem"));
        if(hits.Length > 0)
        {
            
            for(int i = 0; i < hits.Length; i++)
            {
                ClickableObject test = hits[i].collider.gameObject.transform.parent.GetComponent<ClickableObject>();
                if(test != null)
                {
                    //Vector3 localPoint = worldCursor - test.gameObject.transform.position;
                    worldPoint.z = 0;
                    Vector3 localPoint = test.gameObject.transform.InverseTransformPoint(worldPoint);
                    //Debug.Log(localPoint);
                    activeObject = test;
                    test.PickUp();
                    cursorJoint.connectedBody = test.rb;
                    cursorJoint.connectedAnchor = localPoint;
                    cursorJoint.enabled = true;
                    objectHeld = true;
                    break;
                }
            }


        }

        if(activeObject == null)
        {
            Debug.Log("didn't find the thing");
        }
    }

    public void ReleaseObject()
    {
        objectHeld = false;
        activeObject.PutDown();
        activeObject = null;
        cursorJoint.enabled = false;
        cursorJoint.connectedBody = null;
        cursorJoint.connectedAnchor = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if(test != null)
        {
            obstructions++;
            Debug.Log("Stuff in the sink: " + obstructions);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if (test != null)
        {
            obstructions--;
            Debug.Log("Stuff in the sink: " + obstructions);
            if (obstructions <= 0 && positiveAction == false)
            {
                Debug.Log("Sink is clear.");
            }
        }
    }

    public void EndGame()
    {
        if (positiveAction == true)
        {
            Debug.Log("Good end");
            flowChart.ExecuteIfHasBlock("Good End");
        }
        else {
            Debug.Log("Good end");
            flowChart.ExecuteIfHasBlock("Bad End");
        }
            
    }

    public void SetPositiveFlag(bool pos)
    {
        positiveAction = pos;
        if (!positiveAction)
        {
            for (int i = 0; i < cabinetSlot.Count; i++)
            {
                cabinetSlot[i].SetActive(false);
            }
        }
    }
}
