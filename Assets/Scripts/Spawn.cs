using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Bomba ve roket prefabrilleri
    public GameObject bombaPrefab;
    public GameObject roketPrefab;
    public GameObject player;

    // Bomba ve roket spawn oranlar�
    public float bombaSpawnOrani = 0.5f;
    public float roketSpawnOrani = 0.5f;

    // Spawn gecikmesi
    public float spawnGecikmesi = 5.0f;

    // Son spawn zaman�
    private float sonSpawnZamani;

    void Update()
    {
        // Her spawn gecikmesinde yeni bir nesne spawn etme kontrol�
        if (Time.time - sonSpawnZamani >= spawnGecikmesi)
        {
            // Rastgele bir nesne t�r� se�
            float rastgeleSayi = Random.Range(0.0f, 1.0f);

            if (rastgeleSayi < bombaSpawnOrani)
            {
                // Bomba spawn et
                SpawnNesne(bombaPrefab);
            }
            else
            {
                // Roket spawn et
                SpawnNesne(roketPrefab);
            }

            // Son spawn zaman�n� g�ncelle
            sonSpawnZamani = Time.time;
        }
    }

    private void SpawnNesne(GameObject nesnePrefab)
    {
        Vector3 playerAt = player.transform.position;
        // Oyun alan�nda rastgele bir konum olu�tur
        Vector3 spawnKonumu = new Vector3(Random.Range(-1.5f, 1.5f),
                                          playerAt.y + Random.Range(2f, 3f), 
                                          0.0f);

        // Nesneyi spawn et ve ebeveyn olarak ayarla
        GameObject nesne = Instantiate(nesnePrefab, spawnKonumu, Quaternion.identity);
        nesne.transform.parent = transform;
    }
}
