using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    void OnCollisionEnter(Collision collision){
        //set rigidbody usegravity
        GetComponent<Rigidbody>().useGravity = true;
        this.enabled = false; // Disables the script on collision

    }
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //while rigidbody is not colliding with anything, move down
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
