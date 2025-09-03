using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    private const float MinTargetDistance = 0.1f;

    [SerializeField] private List<Transform> _targets;

    private int _currentTargetIndex = 0;

    [CanBeNull] public Transform CurrentTarget { get; private set; }

    private void Update()
    {
        if (CurrentTarget is null)
            return;

        if (Math.Abs(CurrentTarget.position.x - transform.position.x) < MinTargetDistance)
            UpdateTarget();
    }

    public void SetPatrolPoints(List<Transform> targets)
    {
        _targets = targets;

        if (_targets.Count < 1)
            return;

        _currentTargetIndex = 0;
        CurrentTarget = _targets[_currentTargetIndex];
    }

    private void UpdateTarget()
    {
        _currentTargetIndex = ++_currentTargetIndex % _targets.Count;
        CurrentTarget = _targets[_currentTargetIndex];
    }
}