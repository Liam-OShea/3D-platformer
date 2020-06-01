// Reference: gamesplusjames Youtube channel
// https://www.youtube.com/playlist?list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int currHP;
    public int maxHP;
    public PlayerController playerController;
    private bool isRespawning;
    private Vector3 respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
        respawnPoint = playerController.transform.position;
    }

    public void HurtPlayer(int dmg){
        currHP -= dmg;
        if(currHP <= 0){
            Respawn();
        }
    }

    public void Respawn(){
        CharacterController charControl = playerController.GetComponent<CharacterController>();
        charControl.enabled = false;
        charControl.transform.position = respawnPoint;
        charControl.enabled = true;
        currHP = maxHP;
    }
}
