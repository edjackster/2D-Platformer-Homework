using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private const float GroundedCheckDistance = 0.1f;

    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private ContactFilter2D _groundLayer;
    
    public bool IsGrounded { get; private set; }

    private void FixedUpdate()
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        
        Physics2D.CapsuleCast((Vector2) transform.position + _collider.offset, _collider.size, CapsuleDirection2D.Vertical, 0, Vector2.down, _groundLayer, hits, GroundedCheckDistance);
        
        var isGround = hits.Count > 0;
        
        if (isGround == IsGrounded)
            return;
        
        IsGrounded = isGround;
    }
}
