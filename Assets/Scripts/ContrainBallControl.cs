using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrainBallControl : MonoBehaviour
{

    public BoxCollider area;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // public CircleCollider2D area;

    // Update is called once per frame
    void Update()
    {
        if(area = null) 
        {
            return;
        }

        //getting the boundaries
        Vector3 CenterofBox = area.transform.position;  //Get the xyz position of the center of the box
        Vector3 SizeofBox = area.size;                  //Size of the box from one end to the other
        Vector3 Extentofbox = SizeofBox * 0.5f;


        Vector3 MinBoundary = CenterofBox - Extentofbox;
        Vector3 MaxBoundary = CenterofBox + Extentofbox;

        Vector3 ClampedPosition = transform.position;
        ClampedPosition.x = Mathf.Clamp(ClampedPosition.x, MinBoundary.x, MaxBoundary.x);
        ClampedPosition.y = Mathf.Clamp(ClampedPosition.y, MinBoundary.y, MaxBoundary.y);
        ClampedPosition.z = Mathf.Clamp(ClampedPosition.z, MinBoundary.z, MaxBoundary.z);
       
       transform.position = ClampedPosition;
    }

    void LateUpdate()
    {
        // //get thecurrent positioon of the item
        // Vector3 clampedPosition = transform.position;

        // //limit the X and Z axis
        // clampedPosition.x = Mathf.Clamp(clampedPosition.x, area.bounds.min.x, area.bounds.max.x);
        // clampedPosition.z = Mathf.Clamp(clampedPosition.z, area.bounds.min.z, area.bounds.max.z);

        // //z remains unchanged
        // //apply the clamped positions

        // transform.position = clampedPosition;

    }
}
