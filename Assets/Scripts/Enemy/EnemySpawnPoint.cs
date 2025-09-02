using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Enemy _enemy;
    
    public void Spawn()
    {
        var enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.Init(_targets);
    }
}
