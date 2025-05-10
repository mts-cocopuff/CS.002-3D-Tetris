using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using TMPro;


public class ControllerRotation : MonoBehaviour
{
    public Transform targetObject; // The object that will rotate

    void Update()
    {
        if (targetObject == null) return; // Prevent errors if no object is assigned

        // Get the Left Hand controller
        UnityEngine.XR.InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        // Get the controller's rotation position in quaterions (type of rotation)
        if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation))
        {
            // Convert rotation to Euler angles to make it easier to work with
            Vector3 controllerEuler = controllerRotation.eulerAngles;

            // Extract only the Y-axis rotation (this allows us apply this rotation value to the turn table)
            Vector3 targetEuler = targetObject.eulerAngles;
            targetEuler.y = controllerEuler.y; // Apply only Y rotation

            // Apply the new rotation to the target object (the turn table)
            targetObject.rotation = Quaternion.Euler(targetEuler);
        }
    }
}