using UnityEngine;

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
        if (!isDragging) return;

        Vector3 delta = Input.mousePosition - lastMousePosition;
        float rotationX = delta.y * rotationSpeed;
        float rotationY = -delta.x * rotationSpeed;

        transform.Rotate(Vector3.up, rotationY, Space.World);
        transform.Rotate(Vector3.right, rotationX, Space.World);

        lastMousePosition = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isDragging = false;
        SnapRotation();
    }

    void SnapRotation()
    {
        Vector3 currentRotation = transform.eulerAngles;

        currentRotation.x = SnapAngle(currentRotation.x);
        currentRotation.y = SnapAngle(currentRotation.y);
        currentRotation.z = SnapAngle(currentRotation.z);

        transform.eulerAngles = currentRotation;
    }

    float SnapAngle(float angle)
    {
        angle = NormalizeAngle(angle);
        return Mathf.Round(angle / 90f) * 90f;
    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180) angle -= 360;
        return angle;
    }
}
