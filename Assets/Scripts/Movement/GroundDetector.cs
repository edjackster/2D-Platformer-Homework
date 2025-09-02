using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundDetector : MonoBehaviour
{
    private const float GroundedCheckDistance = 0.1f;
    
    [SerializeField]  private ContactFilter2D _groundLayer;
    
    private Rigidbody2D _rigidbody;
    
    public bool IsGrounded { get; private set; }

    public event Action<bool> GroundedChange;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        _rigidbody.Cast(Vector2.down, _groundLayer, hits, GroundedCheckDistance);
        
        var isGround = hits.Count > 0;
        
        if (isGround == IsGrounded)
            return;
        
        GroundedChange?.Invoke(IsGrounded);
        IsGrounded = isGround;
    }
}
