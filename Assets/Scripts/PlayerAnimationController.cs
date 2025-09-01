using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerAnimationController : MonoBehaviour
{
    private static readonly int SpeedY = Animator.StringToHash("speedY");
    private static readonly int SpeedX = Animator.StringToHash("speedX");
    
    [SerializeField] private PlayerInputManager _playerInputManager;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedY, _rigidbody.velocity.y);
    }

    private void OnEnable()
    {
        _playerInputManager.MovementPressed += OnWalkInput;
    }

    private void OnDisable()
    {
        _playerInputManager.MovementPressed -= OnWalkInput;
    }

    private void OnWalkInput(float direction)
    {
        _spriteRenderer.flipX = direction < 0;
        _animator.SetFloat(SpeedX, Math.Abs(direction));
    }
}
