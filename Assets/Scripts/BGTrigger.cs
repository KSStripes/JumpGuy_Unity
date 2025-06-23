using UnityEngine;

public class BGTrigger : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public float backgroundWidth = 64f;

    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned || !other.CompareTag("Player")) return;

        // Spawn new background directly next to the current one (same Y/Z)
        Vector3 spawnPosition = transform.parent.position + new Vector3(backgroundWidth, 0f, 0f);
        Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
        hasSpawned = true;
    }
}
