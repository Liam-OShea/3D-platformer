// Reference: gamesplusjames Youtube channel
// https://www.youtube.com/playlist?list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other){
        Debug.Log("test");
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<PlayerCharacter>().HurtPlayer(damage);
        }
    }
}
