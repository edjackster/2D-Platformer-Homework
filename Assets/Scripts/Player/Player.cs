using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerAnimation _animator;
    [SerializeField] private PlayerAttacker _attacker;
    [SerializeField] private Health _health;
    
    private Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    private void OnEnable()
    {
        _playerInput.MovementPressed += OnMovement;
        _playerInput.JumpPressed += OnJump;
        _playerInput.AttackPressed += OnAttack;
        _health.TookDamage += _animator.Hit;
    }

    private void OnDisable()
    {
        _playerInput.MovementPressed -= OnMovement;
        _playerInput.JumpPressed -= OnJump;
        _playerInput.AttackPressed -= OnAttack;
        _health.TookDamage -= _animator.Hit;
    }

    private void OnMovement(float direction)
    {
        _flipper.Flip(direction);
        _animator.SetSpeed(direction);
        _mover.Move(direction);
    }

    private void OnAttack()
    {
        _attacker.Attack();
    }

    private void OnJump()
    {
        if(_groundDetector.IsGrounded)
            _mover.Jump();
    }
}
