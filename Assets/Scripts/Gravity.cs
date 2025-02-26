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

    void OnCollisionEnter(Collision collision)
    {
        // Set rigidbody useGravity
        GetComponent<Rigidbody>().useGravity = true;
        isColliding = true;
    }

    public float speed;

    public bool IsFalling()
    {
        return !isColliding;
    }

    // Update is called once per frame
    void Update()
    {
        // While rigidbody is not colliding with anything, move down
        if (!isColliding)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

            float nudgespeed = 6f;
            float inout = 0f;
            float sideside = 0f;

            if (Input.GetKey(KeyCode.S))
                inout = -1f;
            else if (Input.GetKey(KeyCode.W))
                inout = 1f;

            if (Input.GetKey(KeyCode.D))
                sideside = 1f;
            else if (Input.GetKey(KeyCode.A))
                sideside = -1f;
            
            transform.Translate(
                Vector3.right * sideside * nudgespeed * Time.deltaTime
                + Vector3.forward * inout * nudgespeed * Time.deltaTime, Space.World
            );
        }
        else{

        }
    }
}
