using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
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
            SpawnStar();
            timer = 0f;
        }
    }

    void SpawnStar()
    {
        float randomX = Random.Range(xMin, xMax);
        Vector2 spawnPos = new Vector2(randomX, ySpawn);
        Instantiate(starPrefab, spawnPos, Quaternion.identity);
    }
}
