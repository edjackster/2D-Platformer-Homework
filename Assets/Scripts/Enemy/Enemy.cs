using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patroller), typeof(Flipper), typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Patroller _patrol;
    private Flipper _flipper;
    private Mover _mover;

    private void Awake()
    {
        _patrol = GetComponent<Patroller>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<Mover>();
    }

    public void Init(List<Transform> targets)
    {
        _patrol.SetPatrolPoints(targets);
    }

    private void Update()
    {
        if(_patrol.CurrentTarget is null)
            return;
        
        int direction;
        
        if(_patrol.CurrentTarget.position.x - transform.position.x < 0)
            direction = -1;
        else
            direction = 1;
        
        _mover.Move(direction);
        _flipper.Flip(direction);
    }
}
