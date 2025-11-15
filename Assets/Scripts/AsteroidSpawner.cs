using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // prefab asteroid
    public float spawnInterval = 2f;
    public float xMin = -8f;
    public float xMax = 8f;
    public float ySpawn = 6f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(xMin, xMax);
        Vector2 spawnPos = new Vector2(randomX, ySpawn);
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
