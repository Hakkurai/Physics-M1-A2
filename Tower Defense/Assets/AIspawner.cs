using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject AI;
    public Transform AIY; // The central location around which the AI will spawn
    public float SpawnTimer = 0;
    public float SpawnRate = 1;
    public float MaxTimer = 3;
    public int MaxWave = 3, CurrentWave = 1;
    public int SpawnCount;
    public int SpawnVar;
    public bool WaveStarted;
    public float SpawnTimerX;
    public float SpawnerCap;

    public float spawnRange = 5f; // The range around the central location to spawn AI

    void Update()
    {
        if (WaveStarted == false)
        {
            SpawnVar = SpawnCount;
            WaveStarted = true;
        }

        switch (CurrentWave)
        {
            case 1:
                SpawnCount = 3;
                break;

            case 2:
                SpawnCount = 5;
                break;

            case 3:
                SpawnCount = 10;
                break;
        }

        SpawnTimer += SpawnRate * Time.deltaTime;

        if (SpawnTimer >= MaxTimer)
        {
            SpawnTimerX += 1 * Time.deltaTime;

            if (SpawnVar != 0 && SpawnTimerX >= SpawnerCap)
            {
                SpawnTimerX = 0;

                // Generate a random position within the specified range
                Vector3 randomOffset = new Vector3(
                    Random.Range(-spawnRange, spawnRange), // Random X offset
                    0,                                    // Keep the same Y position
                    0
                );

                Vector3 spawnPosition = AIY.position + randomOffset; // Add the offset to the object's position

                Instantiate(AI, spawnPosition, Quaternion.identity); // Spawn at the calculated position

                SpawnVar--;
            }
            else if (SpawnVar == 0)
            {
                SpawnTimer = 0;
                WaveStarted = false;
                CurrentWave++;
            }
        }
    }
}
