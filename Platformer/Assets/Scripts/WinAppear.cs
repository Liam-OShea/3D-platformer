// Reference: Bryan Mayrose Youtube Channel
// https://www.youtube.com/watch?v=03L-5c382Ko


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinAppear : MonoBehaviour
{
    [SerializeField] private RawImage myImage;
    

    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            myImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.CompareTag("Player")){
            myImage.enabled = false;
        }
    }
}
