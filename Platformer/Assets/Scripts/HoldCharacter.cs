// Reference: TurnTheGameOn Youtube channel
// https://www.youtube.com/watch?v=AfwmRYQRsbg&t=55s


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour
{
   
    void OnTriggerEnter(Collider col){
        col.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider col){
        col.transform.parent = null;
    }

}
