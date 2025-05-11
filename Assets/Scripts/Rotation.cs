using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using TMPro;

public class RotateSnapSphere : MonoBehaviour
{
    public float rotationSpeed = 1f; // Reduced speed multiplier for smoother rotation
    private Vector3 lastMousePosition;
    private bool isDragging = false;

    void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - lastMousePosition;
        float rotationX = delta.y * rotationSpeed;
        float rotationY = -delta.x * rotationSpeed;

        transform.Rotate(Vector3.up, rotationY, Space.World);
        transform.Rotate(Vector3.right, rotationX, Space.World);

        //Bounds bounds = GetComponent<Collider>().bounds;
        //Vector3 center = bounds.center;

        lastMousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // SnapRotation();
        isDragging = false;
    }

    void Update()
    {
        UnityEngine.XR.InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightController != null)
        {
            if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion controllerRotation))
            {
                Vector3 controllerEuler = controllerRotation.eulerAngles;
                transform.rotation = Quaternion.Euler(controllerEuler);
            }
        }

        RotateNonGravityObjects();
    }

    void RotateNonGravityObjects()
    {
        GameObject[] nonGravityObjects = GameObject.FindGameObjectsWithTag("piece");

        foreach (GameObject obj in nonGravityObjects)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null && !rb.useGravity)
            {
                obj.transform.rotation = transform.rotation;
            }
        }
    }

    public void ResetRotation()
    {
        transform.eulerAngles = new Vector3(0,0,0);
    }
}
