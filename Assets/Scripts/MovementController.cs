using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputManager))]
public class MovementController : MonoBehaviour
{
    private const float GroundedCheckDistance = 0.1f;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInputManager _playerInputManager;
    
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInputManager.JumpPressed += OnJump;
        _playerInputManager.MovementPressed += OnWalk;
    }

    private void OnDisable()
    {
        _playerInputManager.JumpPressed -= OnJump;
        _playerInputManager.MovementPressed -= OnWalk;
    }

    private void OnWalk(float direction)
    {
        transform.Translate(Vector3.right * (direction * _speed * Time.deltaTime));
    }

    private void OnJump()
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        _rigidbody.Cast(Vector2.down, hits, GroundedCheckDistance);
        
        bool isGrounded = hits.Count > 0;
        
        if(isGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
