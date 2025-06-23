using UnityEngine;

public class BGTrigger : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public Transform player;  // assign player in Inspector
    private bool hasSpawned = false;
    
    public Vector3 spawnOffset = new Vector3(128f, 0, 0);
    public float fixedY = 0f;
    public float fixedZ = 0f;

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
            Vector3 spawnPosition = new Vector3(player.position.x, fixedY, fixedZ);
            Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);
            hasSpawned = true;
        }
    }
}
