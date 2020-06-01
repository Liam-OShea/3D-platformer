// Reference: gamesplusjames Youtube channel
// https://www.youtube.com/playlist?list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 camOffset;
    public bool useOffset;
    public float rotationSpeed;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {

        if(!useOffset){
            camOffset = target.position - transform.position;
        }    

        //Move pivot to player location
        pivot.transform.position = target.transform.position;
        //Make pivot a child of player
        pivot.transform.parent = target.transform;
        //Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
    }


    void LateUpdate(){

        //Get the X position of the mouse & rotate the target
        float hor = Input.GetAxis("Mouse X") * rotationSpeed;
        target.Rotate(0, hor, 0);

        //Get the Y Position of the mouse and rotate the pivot
        float vert = Input.GetAxis("Mouse Y") * rotationSpeed;
        pivot.Rotate(-vert, 0, 0);

        //Move the camera based on the current rotation of the target and the original camOffset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * camOffset);        


        //Prevent camera from looking underneath player
        if(transform.position.y < target.position.y){
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
