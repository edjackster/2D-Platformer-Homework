using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";
    
    public event Action JumpPressed;
    public event Action<float> MovementPressed;
    public event Action AttackPressed;

    private void Update()
    {
        if (Input.GetButtonDown(JumpButton))
            JumpPressed?.Invoke();
        
        if (Input.GetMouseButtonDown(0))
            AttackPressed?.Invoke();

        var movement = Input.GetAxis(HorizontalAxis); 
        MovementPressed?.Invoke(movement);
    }
}
