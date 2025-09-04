using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

    private void Awake()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.Spawn();
        }
    }
}
