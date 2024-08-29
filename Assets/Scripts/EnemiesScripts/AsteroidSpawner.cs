using System.Security.Principal;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 2.0f;
    public float spawnRadius = 10.0f;
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.0f, spawnRate);
    }

    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
