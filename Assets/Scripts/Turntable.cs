using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Turntable : MonoBehaviour
{
    public float prevConRot = 0f;
    public float speed = 0f;

    private float targetSpeed = 0f;
    private float acceleration = 0.5f; // Reduced value to reset speed slower

    void Start()
    {
        UnityEngine.XR.InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (leftController != null)
        {
            if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation))
            {
                Vector3 controllerEuler = controllerRotation.eulerAngles;
                prevConRot = controllerEuler.y;
            }
        }
    }

    void FixedUpdate()
    {

        float deltaRotation = 0;
        if (Input.GetMouseButton(1))
        {
            deltaRotation = Input.GetAxis("Mouse X") * -1000;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            deltaRotation = -500f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            deltaRotation = 500f;
        }

        UnityEngine.XR.InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (leftController != null)
        {
            // Get the controller's rotation position in quaterions (type of rotation)
            if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation))
            {
                // Convert rotation to Euler angles to make it easier to work with
                Vector3 controllerEuler = controllerRotation.eulerAngles;

                float changeRot = controllerEuler.y - prevConRot;

                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                GetComponent<Rigidbody>().AddTorque(Vector3.up * changeRot, ForceMode.VelocityChange);

                prevConRot = controllerEuler.y;
            }
        }
        else
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().AddTorque(Vector3.up * deltaRotation * Time.deltaTime, ForceMode.VelocityChange);
        }
        //sGetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0, rotation, 0));
    }
}
