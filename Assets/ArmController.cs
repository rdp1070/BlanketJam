﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.SetPositionAndRotation(Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
