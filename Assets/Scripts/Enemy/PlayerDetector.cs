using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectingRange = 2f;
    [SerializeField] private LayerMask _playerMask;

    private bool _isDetected = false;

    public event Action<Player> PlayerDetected;
    public event Action PlayerLost;

    private void FixedUpdate()
    {
        var hit = Physics2D.Raycast(transform.position, transform.right, _detectingRange,  _playerMask);

        Debug.DrawRay(transform.position, transform.right * _detectingRange, Color.red);

        if (hit.collider is null)
        {
            LoosePlayer();
            return;
        }
        
        bool isDetected = hit.collider.TryGetComponent(out Player player);

        if (isDetected)
            DetectPlayer(player);
        else
            LoosePlayer();
    }

    private void LoosePlayer()
    {
        if(_isDetected == false)
            return;
        
        PlayerLost?.Invoke();
        _isDetected = false;
    }

    private void DetectPlayer(Player player)
    {
        if(_isDetected)
            return;
        
        PlayerDetected?.Invoke(player);
        _isDetected = true;
    }
}