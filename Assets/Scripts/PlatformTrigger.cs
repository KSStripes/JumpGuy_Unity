using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab to spawn based on ExitPoint

    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned || !other.CompareTag("Player")) return;

        // Find ExitPoint of the current platform
        Transform exitPoint = transform.parent.Find("ExitPoint"); 
        if (exitPoint == null)
        {
            Debug.LogError("ExitPoint not found on parent platform.");
            return;
        }

        // Spawn the next platform at the ExitPoint position
        GameObject newPlatform = Instantiate(platformPrefab, exitPoint.position, Quaternion.identity);

        hasSpawned = true;
    }
}
