using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject platformPrefab;
    public Vector3 spawnOffset = Vector3.zero;

    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned) return;

        if (other.CompareTag("Player"))
        {
            Instantiate(platformPrefab, transform.position + spawnOffset, Quaternion.identity);
            hasSpawned = true;
        }
    }
}
