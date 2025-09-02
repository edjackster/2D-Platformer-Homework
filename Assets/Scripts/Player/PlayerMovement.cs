using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInput playerInput;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.JumpPressed += OnJump;
        playerInput.MovementPressed += OnWalk;
    }

    private void OnDisable()
    {
        playerInput.JumpPressed -= OnJump;
        playerInput.MovementPressed -= OnWalk;
    }

    private void OnWalk(float direction)
    {
        transform.Translate(Vector3.right * (Math.Abs(direction) * _speed * Time.deltaTime));
    }

    private void OnJump()
    {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
