using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    public float speed = 0f;

    private float targetSpeed = 0f;
    private float acceleration = 0.5f; // Reduced value to reset speed slower

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            targetSpeed = 0.01f; // Further reduced value for slower rotation
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetSpeed = -0.01f; // Further reduced value for slower rotation
        }
        else
        {
            targetSpeed = 0f;
        }

        speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime);
        GetComponent<Rigidbody>().AddTorque(Vector3.up * speed, ForceMode.VelocityChange);
    }
}
