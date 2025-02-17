using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
	Transform rotationBase;
    float rotation;
    float deltaRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0.0f;
        deltaRotation = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0)) {
            deltaRotation = Input.GetAxis("Mouse X") * -1000;
        } else {
            deltaRotation = 0;
        }
        
        rotation += deltaRotation * Time.deltaTime;
        rotationBase.localRotation = Quaternion.Euler(0, rotation, 0);
        */
    }
}
