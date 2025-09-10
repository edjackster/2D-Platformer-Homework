using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour), typeof(Mover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Flipper _flipper;
    
    private EnemyBehaviour _behaviour;
    private Mover _mover;

    private void Awake()
    {
        _behaviour = GetComponent<EnemyBehaviour>();
        _mover = GetComponent<Mover>();
    }

    public void Init(List<Transform> targets)
    {
        _behaviour.SetPatrolPoints(targets);
    }

    private void Update()
    {
        if(_behaviour.CurrentTarget is null)
            return;
        
        int direction;
        
        if(_behaviour.CurrentTarget.position.x - transform.position.x < 0)
            direction = -1;
        else
            direction = 1;
        
        _mover.Move(direction);
        _flipper.Flip(direction);
    }
}
