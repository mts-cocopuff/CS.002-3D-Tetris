using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    public float speed = 0f;

    private float targetSpeed = 0f;
    private float acceleration = 0.5f; // Reduced value to reset speed slower

    void FixedUpdate()
    {

        float deltaRotation = 0;
        if (Input.GetMouseButton(0))
        {
            deltaRotation = Input.GetAxis("Mouse X") * -1000;
        }
        /*else if (Input.GetKey(KeyCode.D))
        {
            deltaRotation = -500f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            deltaRotation = 500f;
        } */
        
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().AddTorque(Vector3.up * deltaRotation * Time.deltaTime, ForceMode.VelocityChange);
        //sGetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0, rotation, 0));
    }
}
