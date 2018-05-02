using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public CameraControl cam;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            //cam.StartCameraMove(other.gameObject.transform.position.x < transform.position.x ? 21.75f : -21.75f);
            cam.SetCameraTarget(transform.position);
        }
    }
}
