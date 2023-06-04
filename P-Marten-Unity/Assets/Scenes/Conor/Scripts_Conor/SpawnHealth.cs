using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    public GameObject healthPack;
    public float spawnInterval = 10f; // Time interval between spawns
    public float spawnRadius = 5f; // Maximum distance from centre 

    private float spawnTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        // When timer exceeds spawn interval SpawnObject method is called
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        // Generate a random position within the spawn radius
        Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + randomPosition;

        // Spawn the object at the generated position
        Instantiate(healthPack, spawnPosition, Quaternion.identity);
    }
}
