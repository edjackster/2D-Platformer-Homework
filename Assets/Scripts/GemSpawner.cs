using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private Gem _gem;
    [SerializeField] private List<Transform> _gemsSpawnPoint;

    private void Awake()
    {
        foreach (var spawnpoint in _gemsSpawnPoint)
            Instantiate(_gem, spawnpoint.position, Quaternion.identity);
    }
}
