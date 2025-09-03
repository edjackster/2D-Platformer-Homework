using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> spawnPoints;

    private void Awake()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.Spawn();
        }
    }
}
