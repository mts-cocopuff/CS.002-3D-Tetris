using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    public float speed = 0f;

    private float targetSpeed = 0f;
    private float acceleration = 2f; // Adjust this value to control the smoothness

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            targetSpeed = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetSpeed = -1f;
        }
        else
        {
            targetSpeed = 0f;
        }

        speed = Mathf.Lerp(speed, targetSpeed, acceleration * Time.deltaTime);
        GetComponent<Rigidbody>().AddTorque(Vector3.up * speed, ForceMode.VelocityChange);
    }
}
