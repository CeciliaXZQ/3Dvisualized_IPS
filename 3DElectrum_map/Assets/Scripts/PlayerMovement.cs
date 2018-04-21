using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float walkSpeed;
    CharacterController charControl;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }
    

    // Update is called once per frame
    void Update () {
        MovePlayer();
	}

    void MovePlayer()
    {
        float horiz= Input.GetAxis("Horizontal")*walkSpeed;
        float vert= Input.GetAxis("Vertical")*walkSpeed;

        transform.position = new Vector3(transform.position.x + horiz, transform.position.y, transform.position.z + vert);
       Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);
    }
}
