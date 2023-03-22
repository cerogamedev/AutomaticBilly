using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;         // The prefab of the object to spawn
    public float spawnInterval = 1f;        // The interval at which to spawn objects
    public Vector2 spawnAreaSize = Vector2.one;  // The size of the area in which to spawn objects
    public Vector2 spawnAreaCenter = Vector2.zero;  // The center of the area in which to spawn objects

    private float spawnTimer;               // The timer for spawning objects

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // If the spawn timer has reached the spawn interval, spawn an object
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();

            // Reset the spawn timer
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        // Generate a random position within the spawn area
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                                            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f))
                                + spawnAreaCenter;

        // Instantiate the object at the spawn position
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
