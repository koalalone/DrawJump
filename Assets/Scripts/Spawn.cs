using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject bombPrefab;
    public GameObject rocketPrefab;
    public GameObject coinPrefab;
    public GameObject player;

    public float bombaSpawnOrani = 0.2f;
    public float roketSpawnOrani = 0.4f;

    public float spawnCooldown = 5.0f;

    private float lastSpawnTime;

    void Update()
    {

        if (Time.time - lastSpawnTime >= spawnCooldown)
        {

            float rastgeleSayi = Random.Range(0.0f, 1.0f);

            if (rastgeleSayi < bombaSpawnOrani)
            {
                SpawnNesne(bombPrefab);
            }
            else if (rastgeleSayi < roketSpawnOrani)
            {
                SpawnNesne(rocketPrefab);
            }
            else
            {
                SpawnNesne(coinPrefab);
            }

            lastSpawnTime = Time.time;
        }
    }

    private void SpawnNesne(GameObject nesnePrefab)
    {
        Vector3 playerAt = player.transform.position;

        Vector3 spawnKonumu = new Vector3(Random.Range(-1.5f, 1.5f),
                                          playerAt.y + Random.Range(2f, 3f), 
                                          0.0f);

        GameObject nesne = Instantiate(nesnePrefab, spawnKonumu, Quaternion.identity);
        nesne.transform.parent = transform;
    }
}
