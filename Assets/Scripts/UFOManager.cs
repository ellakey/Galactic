using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManager : MonoBehaviour
{
    [SerializeField] private GameObject ufoPrefab;
    [SerializeField] private float spawnDelay = 15f; // how long before UFO appears
    [SerializeField] private Transform spawnPoint;

    private bool ufoSpawned = false;

    void Update()
    {
        if (!ufoSpawned && Time.timeSinceLevelLoad >= spawnDelay)
        {
            SpawnUFO();
        }
    }

    void SpawnUFO()
    {
        Instantiate(ufoPrefab, spawnPoint.position, Quaternion.identity);
        ufoSpawned = true;
    }
}
