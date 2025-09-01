using System;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public event Action<Vector3> OnTargetChanged;
    
    [SerializeField] private float _speed;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    
    private Vector3 _target;

    private void Awake()
    {
        if(_end == null)
            return;
        
        _target = new Vector3(_end.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if(_end is null || _start is null)
            return;
        
        _target.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        
        if(Mathf.Approximately(transform.position.x, _end.position.x))
            UpdateTarget(_start);
        
        if(Mathf.Approximately(transform.position.x, _start.position.x))
            UpdateTarget(_end);
    }

    public void SetPatrolPoints(Transform start, Transform end)
    {
        _start = start;
        _end = end;
        _target = new Vector3(_end.position.x, transform.position.y, transform.position.z);
    }

    private void UpdateTarget(Transform target)
    {
        _target = new Vector3(target.position.x, transform.position.y, transform.position.z);
        OnTargetChanged?.Invoke(_target);
    }
}
