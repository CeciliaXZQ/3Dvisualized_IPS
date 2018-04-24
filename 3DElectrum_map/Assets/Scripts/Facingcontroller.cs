using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Facingcontroller : MonoBehaviour {
    public string[] items;
    public string[] axis;
    public float constantY = 1;
    int i;
    float xDiffinReal, zDiffinReal, xDiffinVir, zDiffinVir, xNewPos, zNewPos;

    float velocity = 5;
    float turnSpeed = 10;
    public GameObject myCube;
    public Vector3 targetPos;
    public Vector3 myPosition;
    Vector2 input; //horizontal & vertical
    float angle;
    Quaternion targerRotation;

    GameObject AnchorPoint;
    public float anchorUnityX, anchorUnityZ, anchorAtlasX, anchorAtlasZ, pixelsPerMeter;
    float NewInputX, NewInputZ;
    float scale = 45.0f; //scale:1:450

    // Update is called once per frame
    void Update () {
 
        if (i < items.Length)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetDataValue(items[i]);
                UpdateNewPosition(NewInputX,NewInputZ);
                anchorAtlasX = NewInputX;
                anchorAtlasZ = NewInputZ;

                anchorUnityX = xNewPos;
                anchorUnityZ = zNewPos;
                print("From atlas: " + anchorAtlasX + ", " + anchorAtlasZ);
                targetPos.Set(anchorUnityX, constantY, anchorUnityZ);
                print("Target: "+ targetPos);
                i++;


            }
        }
                Rotate();
                Move(targetPos);

                LogMyPosition();
    }

    //Calculate direction relative to the camera's rotation
    void CalculateDir()
    {
      //angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Atan2(myCube.transform.position.x, myCube.transform.position.z);
        angle = Mathf.Rad2Deg * angle;
    //  angle += cam.eulerAngles.y;
    }

    //Rotate towards calculated angle
    void Rotate()
    {
        targerRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targerRotation, turnSpeed * Time.deltaTime);
    }

    //The player move towards the target position
    void Move(Vector3 myTarget)
    {
      //transform.position += transform.forward * velocity * Time.deltaTime;
        float step = velocity * Time.deltaTime;
   //     print("I am moving!");
     //   print(myTarget);
        transform.position = Vector3.MoveTowards(transform.position, myTarget, step);
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
        AnchorPoint = GameObject.Find("AnchorPoint");
    }

    void GetDataValue(string data)
    {
        axis = items[i].Split('|');
        float.TryParse(axis[0],out NewInputX);
        float.TryParse(axis[2], out NewInputZ);
    }

    void UpdateNewPosition(float NewInputX, float NewInputZ)
    {
        xDiffinReal = Mathf.Abs(NewInputX - anchorAtlasX);
        xDiffinVir = xDiffinReal / scale;
        print(xDiffinReal + "//" + xDiffinVir);

        zDiffinReal = Mathf.Abs(NewInputZ - anchorAtlasZ);
        zDiffinVir = zDiffinReal / scale;
        print(zDiffinReal + "//" + zDiffinVir);

        if (NewInputX > anchorAtlasX)
        {
            xNewPos = anchorUnityX + xDiffinVir;
        }
        else
        {
            xNewPos = anchorUnityX - xDiffinVir;
        }

        if (NewInputZ > anchorAtlasZ)
        {
            zNewPos = anchorUnityZ + zDiffinVir;
        }
        else
        {
            zNewPos = anchorUnityZ - zDiffinVir;
        }
    } 
}
