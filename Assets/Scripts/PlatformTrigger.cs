using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned || !other.CompareTag("Player")) return;

        Transform exitPoint = transform.parent.Find("ExitPoint");
        if (exitPoint == null)
        {
            Debug.LogError("ExitPoint not found on parent platform.");
            return;
        }

        PlatformManager manager = FindObjectOfType<PlatformManager>();
        if (manager != null)
        {
            manager.SpawnPlatform(exitPoint.position);
        }
        else
        {
            Debug.LogError("PlatformManager not found in scene.");
        }

        hasSpawned = true;
    }
}
