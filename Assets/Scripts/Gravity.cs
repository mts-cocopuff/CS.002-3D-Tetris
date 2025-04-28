using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using TMPro;

public class Gravity : MonoBehaviour
{
    public GameObject BaseObject;
    private bool isColliding = false;
    Turntable turntableScript;

    // private InputDevice LeftInputController;

    void Start()
    {
        turntableScript = BaseObject.GetComponent<Turntable>();
        UnityEngine.XR.InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("base") || collision.gameObject.CompareTag("piece"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            isColliding = true;
        }
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

            //      <---->
            //Get the x y axis positions of the right hand  (secondary) controller thumbstick
            Vector2 axis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            // inputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            
            inout = axis.y;  // forward/backward movement
            sideside = axis.x; // left/right movement
          
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
