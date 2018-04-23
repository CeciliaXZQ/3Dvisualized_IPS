using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Facingcontroller : MonoBehaviour {
    public float velocity = 5;
    public float turnSpeed = 10;
    public GameObject myCube;
    public Vector3 targetPos;
    public Vector3 myPosition;
    Vector2 input; //horizontal & vertical
    float angle;
    Quaternion targerRotation;
   // Transform cam;
	
	// Update is called once per frame
	void Update () {
    //    GetInput();
     //   if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

     //   CalculateDir();
        Rotate();
        Move();

        LogMyPosition();

        if (Input.GetKeyDown(KeyCode.Mouse0)) { targetPos.Set(myPosition.x + 1, myPosition.y + 1, myPosition.z + 1); }
       
    }
    
    //Input based on Horizontal(a,d,left,right) and Vertical(w,s,up,down) keys
    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    //Calculate direction relative to the camera's rotation
    void CalculateDir()
    {
        //   angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Atan2(myCube.transform.position.x, myCube.transform.position.z);
        angle = Mathf.Rad2Deg * angle;
    //    angle += cam.eulerAngles.y;
    }

    //Rotate towards calculated angle
    void Rotate()
    {
        targerRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targerRotation, turnSpeed * Time.deltaTime);
    }

    //The player only move along its foward axis
    void Move()
    {
        //   transform.position += transform.forward * velocity * Time.deltaTime;
        float step = velocity * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }

    void LogMyPosition()
    {
        myPosition = myCube.transform.position;
    }

}
