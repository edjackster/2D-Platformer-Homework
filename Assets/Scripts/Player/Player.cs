using System;
using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    
    private Flipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    private void OnEnable()
    {
        _playerInput.MovementPressed += OnMovement;
    }

    private void OnDisable()
    {
        _playerInput.MovementPressed -= OnMovement;
    }

    private void OnMovement(float direction)
    {
        _flipper.Flip(direction);
    }
}
