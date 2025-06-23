using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // add player to camera
    public Vector3 offset = new Vector3(0f, 0f, -10f); //maintain camera distance
    public float smoothSpeed = 5f; // camera move speed

    void LateUpdate()
    {
        {
            if (target != null)
            {
                Vector3 pos = target.position + offset;
                Vector3 smoothed = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
                transform.position = smoothed;
            }
        }
    }
}
