using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using TMPro;
using debug = UnityEngine.Debug;
public class Gravity : MonoBehaviour
{
    public GameObject BaseObject;
    private bool isColliding = false;
    Turntable turntableScript;

    float slamspeed = 5f;

    // private InputDevice LeftInputController;

    void Start()
    {
        turntableScript = BaseObject.GetComponent<Turntable>();
        UnityEngine.XR.InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    public void Drop()
    {
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
            UnityEngine.XR.InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

            //get trigger value from right controller if possible, or set trigger value to 0 to avoid slam effects

            float triggerValue = 0f;

            if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerValue))
            {
                if (triggerValue > 0.1f)
                {
                    transform.Translate(Vector3.down * (speed + (slamspeed * triggerValue)) * Time.deltaTime, Space.World);
                }
                else
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

                }
                
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            }

            // if (triggerValue > 0.1f) debug.Log("slampiece: " + triggerValue); // if the trigger is pressed, print the value

            // transform.Translate(Vector3.down * (speed +(slamspeed*triggerValue)) * Time.deltaTime, Space.World);

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

            
            if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation))
            {
                transform.rotation = controllerRotation* Quaternion.Euler(30, 30, 30);
            }

        }
        else{

        }
    }
}
