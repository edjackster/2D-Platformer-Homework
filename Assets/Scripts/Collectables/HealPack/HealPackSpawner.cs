using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealPackSpawner : MonoBehaviour
{
    [SerializeField] private HealPack _healPack;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private int _healPacksCount;

    private void Awake()
    {
        HealPack healPack;
        
        var spawnpoints = _spawnPoints.ToList();
        
        for (int i = 0; i < _healPacksCount; i++)
        {
            var spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
            healPack = Instantiate(_healPack, spawnpoint.position, Quaternion.identity);
            healPack.HealPackCollected += OnHealPackCollected;
            spawnpoints.Remove(spawnpoint);
        }
    }

    private void OnValidate()
    {
        if(_healPacksCount > _spawnPoints.Count)
            _healPacksCount = _spawnPoints.Count;
    }

    private void OnHealPackCollected(HealPack healPack)
    {
        healPack.HealPackCollected -= OnHealPackCollected;
        healPack.gameObject.SetActive(false);
    }
}
