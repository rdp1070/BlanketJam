using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        if (player != null)
            transform.SetPositionAndRotation(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
