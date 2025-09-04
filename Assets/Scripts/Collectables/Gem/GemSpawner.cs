using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private Gem _gem;
    [SerializeField] private List<Transform> _gemsSpawnPoint;

    private void Awake()
    {
        Gem gem;
        
        foreach (var spawnpoint in _gemsSpawnPoint)
        {
            gem = Instantiate(_gem, spawnpoint.position, Quaternion.identity);
            gem.GemCollected += OnGemCollected;
        }
    }

    private void OnGemCollected(Gem gem)
    {
        gem.GemCollected -= OnGemCollected;
        gem.gameObject.SetActive(false);
    }
}
