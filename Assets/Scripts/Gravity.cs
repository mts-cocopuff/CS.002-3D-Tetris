using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{

    public GameObject BaseObject;
    private bool isColliding = false;
    Turntable turntableScript;


    void Start()
    {
        turntableScript = BaseObject.GetComponent<Turntable>();
    }

    void OnCollisionEnter(Collision collision){
        //set rigidbody usegravity
        GetComponent<Rigidbody>().useGravity = true;
        isColliding = true;
    }
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //while rigidbody is not colliding with anything, move down
        if (!isColliding)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else{
            
        }
    }
}
