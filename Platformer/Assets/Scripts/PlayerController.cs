// Reference: gamesplusjames Youtube channel
// https://www.youtube.com/playlist?list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpIntensity;
    public CharacterController charController;
    private Vector3 moveDir;
    public float gravityIntensity;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    
        float yTemp = moveDir.y;

        moveDir = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDir = moveDir.normalized * speed;
        //Unnormalize falling/jumping
        moveDir.y = yTemp;
        
        if(charController.isGrounded){
            moveDir.y = 0f; //Prevent gravity from building
            if(Input.GetButtonDown("Jump")){
                moveDir.y = jumpIntensity;
            }
        }

        moveDir.y = moveDir.y + (gravityIntensity * Physics.gravity.y) * Time.deltaTime;
        charController.Move(moveDir * Time.deltaTime);
    }
}
