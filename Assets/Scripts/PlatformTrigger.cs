using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject platformPrefab;

    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned || !other.CompareTag("Player")) return;

        // Use trigger X , and fixed Y/Z
        Vector3 spawnPosition = new Vector3(transform.position.x + 5, 0, 0);

        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        hasSpawned = true;
    }
}
