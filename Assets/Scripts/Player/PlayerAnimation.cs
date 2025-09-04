using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private static readonly int SpeedY = Animator.StringToHash("speedY");
    private static readonly int SpeedX = Animator.StringToHash("speedX");
    private static readonly int Hurt = Animator.StringToHash("hurt");
    
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

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedX, Math.Abs(speed));
    }

    public void Hit()
    {
        _animator.SetTrigger(Hurt);
    }
}
