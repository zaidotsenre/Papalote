using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObjectPool obstaclePool;
    [SerializeField] float spawnFrequency;
    [SerializeField] float spawnFrequencyDecrement;
    [SerializeField] float minSpawnFrequency;

    private void Start()
    {
        Invoke("SpawnOne", spawnFrequency);
        InvokeRepeating("DecreaseSpawnFrequency", 10, 10);
    }

    void SpawnOne()
    {
        obstaclePool.GetNext().SetActive(true);
        Invoke("SpawnOne", spawnFrequency);
    }

    void DecreaseSpawnFrequency()
    {
        spawnFrequency -= spawnFrequencyDecrement;
        if (spawnFrequency < minSpawnFrequency)
            spawnFrequency = minSpawnFrequency;
    }
}
