using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Vector3 cameraShiftDistance;
    public Vector3 currentTrackingTarget;
    public float cameraTrackSpeed;
    public bool moving = false;
    
	// Update is called once per frame
    void Start()
    {
        currentTrackingTarget = transform.position;
    }

	void Update ()
    {
        if(moving)
        {
            Vector2 toTarget = currentTrackingTarget - transform.position;
            if (toTarget.magnitude < cameraTrackSpeed * Time.deltaTime)
            {
                transform.position = currentTrackingTarget;
                moving = false;
            }
            else
            {
                transform.position += (Vector3)toTarget.normalized * cameraTrackSpeed * Time.deltaTime;
            }

        }    
    }

    public void StartCameraMove(float distance)
    {
        currentTrackingTarget += Vector3.right * distance; 
        moving = true;
    }

    public void SetCameraTarget(Vector3 target)
    {
        currentTrackingTarget = target;
        moving = true;
    }
}
