using UnityEngine;

[RequireComponent(typeof(PatrolMovement), typeof(EnemyAnimationController))]
public class Enemy : MonoBehaviour
{
    private PatrolMovement _patrol;
    private EnemyAnimationController _animationController;

    private void Awake()
    {
        _patrol = GetComponent<PatrolMovement>();
        _animationController = GetComponent<EnemyAnimationController>();
    }

    private void OnEnable()
    {
        _patrol.OnTargetChanged += OnTargetChange;
    }

    private void OnDisable()
    {
        _patrol.OnTargetChanged -= OnTargetChange;
    }

    public void Init(Transform start, Transform end)
    {
        _patrol.SetPatrolPoints(start, end);
    }

    private void OnTargetChange(Vector3 target)
    {
        _animationController.SetDirection(target.x - transform.position.x);
    }
}
