using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 1.0f; //distance between player and camera
    //calutae the position:
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    //avoid flip of the camera:
    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    // Use this for initialization
    private void Start () {
        camTransform = transform;
        cam = Camera.main;  //tag as main camera
	}

    private void Update(){
        
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

	// Update is called once per frame
	private void LateUpdate () {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
	}
}
