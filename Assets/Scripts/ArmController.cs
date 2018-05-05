using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        SetArmPosition();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.SetPositionAndRotation(Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        SetArmPosition();
    }

    public void SetArmPosition()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        transform.position = worldPos;
    }
}
