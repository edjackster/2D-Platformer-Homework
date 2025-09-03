using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Patroller _patroller;

    [CanBeNull] public Transform CurrentTarget { get; private set; }

    private void Update()
    {
        if (_chaser.CurrentTarget is null)
            CurrentTarget = _patroller.CurrentTarget;
        else
            CurrentTarget = _chaser.CurrentTarget;
    }

    public void SetPatrolPoints(List<Transform> targets)
    {
        _patroller.SetPatrolPoints(targets);
    }
}