using UnityEngine;

[RequireComponent(typeof(PatrolMovement), typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    private PatrolMovement _patrol;
    private Flipper _flipper;

    private void Awake()
    {
        _patrol = GetComponent<PatrolMovement>();
        _flipper = GetComponent<Flipper>();
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
        _flipper.Flip(target.x - transform.position.x);
    }
}
