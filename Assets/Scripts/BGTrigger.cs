using UnityEngine;

public class BGTrigger : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public Transform player;  // assign player in Inspector
    private bool hasSpawned = false;

    void Start()
    {
        // Auto-assign player if not done in Inspector
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasSpawned) return;

        if (other.CompareTag("Player"))
        {
            // Spawn relative to current player position
            Vector3 spawnPosition = player.position;
            Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
            hasSpawned = true;
        }
    }
}
