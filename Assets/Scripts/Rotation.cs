using UnityEngine;

public class RotateSnapSphere : MonoBehaviour
{
    public float rotationSpeed = 1f; // Reduced speed multiplier for smoother rotation
    private Vector3 lastMousePosition;

    void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        // if (!isDragging) return;

        Vector3 delta = Input.mousePosition - lastMousePosition;
        float rotationX = delta.y * rotationSpeed;
        float rotationY = -delta.x * rotationSpeed;

        Bounds bounds = GetComponent<Collider>().bounds;
        Vector3 center = bounds.center;

        lastMousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // SnapRotation();
        isDragging = false;
    }

    void Update()
    {
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
