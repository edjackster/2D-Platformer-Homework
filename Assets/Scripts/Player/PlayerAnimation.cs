using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private static readonly int SpeedY = Animator.StringToHash("speedY");
    private static readonly int SpeedX = Animator.StringToHash("speedX");
    
    [SerializeField] private PlayerInput _playerInput;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedY, _rigidbody.velocity.y);
    }

    private void OnEnable()
    {
        _playerInput.MovementPressed += OnWalkInput;
    }

    private void OnDisable()
    {
        _playerInput.MovementPressed -= OnWalkInput;
    }

    private void OnWalkInput(float direction)
    {
        _animator.SetFloat(SpeedX, Math.Abs(direction));
    }
}
