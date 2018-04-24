using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Facingcontroller : MonoBehaviour {
    public string[] items;
    public string[] axis;
    public float Xparser;
    public float Yparser;
    public float Zparser;
    int i;

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

        if (i < items.Length)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetDataValue(items[i]);
                //    print (i);
                i++;
                //targetPos.Set(myPosition.x + 1, myPosition.y + 1, myPosition.z + 1);
                targetPos.Set(Xparser, Yparser, Zparser);

            }
        }

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

    IEnumerator Start()
    {
        WWW LocationInfo = new WWW("http://localhost/ConnectUnity/LocationInfo");
        yield return LocationInfo;
        string itemDataString = LocationInfo.text;
        string positionInfo = LocationInfo.text;
        print(itemDataString);
        items = itemDataString.Split(';');
      
        //  print(GetDataValue(items[2], "Pos_Z:"));
      
    }

    void GetDataValue(string data)
    {
        //  string value = data.Substring(data.IndexOf(index) + index.Length);
        // if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        axis = items[i].Split('|');
        float.TryParse(axis[0],out Xparser);
        float.TryParse(axis[1], out Yparser);
        float.TryParse(axis[2], out Zparser);
        // Yparser = float.Parse(axis[1]);
        //Zparser = float.Parse(axis[2]);

    }
}
