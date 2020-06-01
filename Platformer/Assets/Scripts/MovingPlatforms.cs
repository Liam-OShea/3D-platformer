// Reference: TurnTheGameOn Youtube channel
// https://www.youtube.com/watch?v=AfwmRYQRsbg&t=55s


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
    public string currentState;
    public float smooth;
    public float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTarget();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
    }

    void ChangeTarget(){
        if(currentState == "To Position 1"){
            currentState = "To Position 2";
            newPosition = position2.position;
        } else if(currentState == "To Position 2"){
            currentState = "To Position 1";
            newPosition = position1.position;
        } else if(currentState == ""){
            currentState = "To Position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}
