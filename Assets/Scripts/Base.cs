using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    GameObject wallHeight;
    float rotation;
    float deltaRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0.0f;
        deltaRotation = 5.0f;

        int speed = PlayerPrefs.GetInt("speed", 3);

        if(speed == 5){
            wallHeight.transform.localScale = new Vector3(0.06666667f, 1, 0.06666667f);
        }
        else if(speed == 7){
            //disable wallHeight
            wallHeight.SetActive(false);
        }
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
