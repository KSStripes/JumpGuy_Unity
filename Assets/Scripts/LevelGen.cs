using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGen : MonoBehaviour
{
    public GameObject startPlatform;
    public GameObject finishPlatform;
    public GameObject[] middlePlatforms;
    public Transform player;

    public int totalMiddlePlatforms = 10;
    public float triggerDistance = 5f;

    private int spawnedCount = -1; // -1 means start platform not spawned
    private float nextSpawnX = 0f;

    void Update()
    {
        // Only spawn ONE platform per frame if player is close enough
        if (spawnedCount <= totalMiddlePlatforms &&
            player.position.x + triggerDistance > nextSpawnX)
        {
            SpawnNextPlatform();
        }
    }

    void SpawnNextPlatform()
    {
        GameObject platformToSpawn;

        if (spawnedCount == -1)
        {
            platformToSpawn = startPlatform;
        }
        else if (spawnedCount < totalMiddlePlatforms)
        {
            platformToSpawn = middlePlatforms[Random.Range(0, middlePlatforms.Length)];
        }
        else
        {
            platformToSpawn = finishPlatform;
        }

        GameObject segment = Instantiate(platformToSpawn, new Vector3(nextSpawnX, 0, 0), Quaternion.identity);
        nextSpawnX += GetPlatformWidth(segment);
        spawnedCount++;
    }


    float GetPlatformWidth(GameObject platform)
    {
        Tilemap tilemap = platform.GetComponentInChildren<Tilemap>();
        if (tilemap == null) return 20f; // fallback
        return tilemap.cellBounds.size.x * tilemap.cellSize.x;
    }
}
