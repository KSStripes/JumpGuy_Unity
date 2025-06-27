using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;

    public void SpawnPlatform(Vector3 spawnPosition)
    {
        if (platformPrefabs.Length == 0)
        {
            Debug.LogWarning("No platform prefabs assigned to PlatformManager.");
            return;
        }

        // Choose a random prefab
        GameObject selected = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

        // Instantiate at the given position
        Instantiate(selected, spawnPosition, Quaternion.identity);
    }
}
