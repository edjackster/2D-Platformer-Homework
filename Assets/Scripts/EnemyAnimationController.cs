using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyAnimationController : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private PatrolMovement _patrolMovement;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(float direction)
    {
        _renderer.flipX = direction > 0;
    }
}
