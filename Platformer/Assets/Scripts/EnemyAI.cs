// Reference: JustTechStuff Youtube Channel
// https://www.youtube.com/watch?v=LDcIDUAXVFU



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    Transform playerTransform;
    //Navmesh must be baked inside unity
    UnityEngine.AI.NavMeshAgent navmesh;
    public float checkingRate = 0.01f;
    float nextCheck;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        navmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextCheck){
            nextCheck = Time.time + checkingRate;
            FollowPlayer();
        }
    }

    void FollowPlayer(){
        navmesh.transform.LookAt(playerTransform);
        navmesh.destination = playerTransform.position;
    }
}
