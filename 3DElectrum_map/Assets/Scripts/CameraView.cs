using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {
    public Transform playerbody;
    public float mouseSensitivity;
    float xAxisClamp = 0.0f;
    public Vector3 targetPos;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	
	// Update is called once per frame
	void Update () {
     //   playerbody.LookAt(targetPos);
        RotateCamera();
	}

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
      //  Vector3 targetRotBody = playerbody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotCam.y += rotAmountX;

        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }

        if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

     //   print(mouseY);

        transform.rotation = Quaternion.Euler(targetRotCam);
      //  playerbody.rotation = Quaternion.Euler(targetRotBody);
    }
}
