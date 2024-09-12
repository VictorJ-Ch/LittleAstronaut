using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject[] prefabs;
    public Transform[] spawner;
    List <GameObject> spawnedAsteroids = new List<GameObject>();
    IEnumerator Start()
    {
        while(true)
        {
            GameObject newAsteroid = Instantiate
            (
                prefabs[Random.Range(0,prefabs.Length)],
                spawner[Random.Range(0,spawner.Length)].position,
                Quaternion.identity
            );
            spawnedAsteroids.Add(newAsteroid);
            //Remove first clone
            StartCoroutine(RemoveFirstClone());
            yield return new WaitForSeconds (timeToSpawn);
        }
    }
    IEnumerator RemoveFirstClone()
    {
        yield return new WaitForSeconds(10.0f);
        if(spawnedAsteroids.Count > 0)
        {
            GameObject asteroidToRemove = spawnedAsteroids[0];
            spawnedAsteroids.RemoveAt(0);
            Destroy(asteroidToRemove);
        }
    }
}
