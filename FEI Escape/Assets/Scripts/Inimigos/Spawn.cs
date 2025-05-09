using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]

    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float sapwnInterval;

        public int spawnCount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPreFab;

    }


    public List<Wave> waves;

    public int currentWaveCount;

    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().Transform;
        CalculateWaveQuota();
        SpawnEnemies();
    }

    void Update()
    {


    }


    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);

    }


    void SpawnEnemies()
    {
        if(waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota)
        {
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    Vector2 spawnPosition = new Vector2(player.Transform.position.x + Random.Range(-10f, 10f), player.Transform.position.y + Random.Range(-10f, 10f));
                    Instantiate(enemyGroup.enemyPreFab, spawnPosition, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;

                }
            }
        }
    }



}



