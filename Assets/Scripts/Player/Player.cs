using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerAnimation _animator;
    [SerializeField] private PlayerMeleeAttacker _attacker;
    [SerializeField] private PlayerVampireAttacker _vampireAttacker;
    [SerializeField] private HealthSystem _health;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private VampireAttackView _vampireAttackView;

    private void OnEnable()
    {
        _playerInput.MovementPressed += OnMovement;
        _playerInput.JumpPressed += OnJump;
        _playerInput.AttackPressed += OnAttack;
        _playerInput.VampireAttackPressed += OnVampireAttack;
        _vampireAttacker.AttackStarted += OnVampireAttackStart;
        _vampireAttacker.AttackEnded += OnVampireAttackEnd;
        _health.TookDamage += _animator.Hit;
    }

    private void OnDisable()
    {
        _playerInput.MovementPressed -= OnMovement;
        _playerInput.JumpPressed -= OnJump;
        _playerInput.AttackPressed -= OnAttack;
        _vampireAttacker.AttackStarted -= OnVampireAttackStart;
        _vampireAttacker.AttackEnded -= OnVampireAttackEnd;
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

    private void OnVampireAttack()
    {
        _vampireAttacker.Attack();
    }

    private void OnVampireAttackStart()
    {
        _vampireAttackView.ShowAura(true);
    }

    private void OnVampireAttackEnd()
    {
        _vampireAttackView.ShowAura(false);
    }

    private void OnJump()
    {
        if(_groundDetector.IsGrounded)
            _mover.Jump();
    }
}
