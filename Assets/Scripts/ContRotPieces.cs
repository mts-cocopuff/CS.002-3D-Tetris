using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;



public class ContRotPieces : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // UnityEngine.XR.InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // // Get the controller's rotation position in quaterions (type of rotation)
        // if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation))
        // {
            
        //     GameObject[] Fallingpieces = GameObject.FindGameObjectsWithTag("piece");

        //     foreach (GameObject piece in Fallingpieces)
        //     {
        //         Gravity gravityScript = piece.GetComponent<Gravity>();
        //         if (gravityScript != null && gravityScript.IsFalling())
        //         {
        //             // Apply the controller's rotation only to falling pieces
        //             piece.transform.rotation = controllerRotation;
        //         }   
        //     }

        // }
    }
}
