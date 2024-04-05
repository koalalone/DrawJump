using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject bombPrefab;
    public GameObject rocketPrefab;
    public GameObject coinPrefab;
    public GameObject player;

    public float bombSpawnRate = 0.4f;
    public float rocketSpawnRate = 0.8f;

    private float spawnCooldown;
    private float lastSpawnTime;

    void Update()
    {
        spawnCooldown = Random.Range(3.0f, 5.0f);

        if (Time.time - lastSpawnTime >= spawnCooldown)
        {

            float randomNumber = Random.Range(0.0f, 1.0f);

            if (randomNumber < bombSpawnRate)
            {
                SpawnObject(bombPrefab);
            }
            else if (randomNumber < rocketSpawnRate)
            {
                SpawnObject(rocketPrefab);
            }
            else
            {
                SpawnObject(coinPrefab);
            }

            lastSpawnTime = Time.time;
        }
    }

    private void SpawnObject(GameObject spawnPrefab)
    {
        Vector3 playerAt = player.transform.position;

        Vector3 spawnLocation = new Vector3(Random.Range(-1.5f, 1.5f),
                                          playerAt.y + Random.Range(2f, 3f), 
                                          0.0f);

        GameObject spawnedObject = Instantiate(spawnPrefab, spawnLocation, Quaternion.identity);
        spawnedObject.transform.parent = transform;
    }
}
