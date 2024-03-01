using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Only modify x position, keep the y and z positions unchanged
        smoothedPosition.y = transform.position.y;
        smoothedPosition.z = transform.position.z;

        transform.position = smoothedPosition;
    }
}