using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //print("In contact with " + collisionInfo.transform.name);
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        //print("No longer in contact with " + collisionInfo.transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
