using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Enemy _enemy;
    
    public void Spawn()
    {
        var enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.Init(_start, _end);
    }
}
