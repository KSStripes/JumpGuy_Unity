using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;         // Assign player in the Inspector
    public float smoothSpeed = 5f;   // Camera smoothing speed
    private float fixedY;            // Y position to lock
    private float fixedZ;            // Z position to lock

    void Start()
    {
        fixedY = transform.position.y;     // Lock initial Y
        fixedZ = transform.position.z;     // Lock initial Z (-10 for 2D)
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Follow only X, lock Y and Z
            Vector3 desiredPos = new Vector3(target.position.x, fixedY, fixedZ);
            transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        }
    }
}
