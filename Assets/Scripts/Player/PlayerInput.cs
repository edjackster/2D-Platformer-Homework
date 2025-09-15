using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    public event Action JumpPressed;
    public event Action<float> MovementPressed;
    public event Action AttackPressed;
    public event Action VampireAttackPressed;

    private void Update()
    {
        if (Input.GetButtonDown(JumpButton))
            JumpPressed?.Invoke();
        
        if (Input.GetMouseButtonDown(RightMouseButton))
            VampireAttackPressed?.Invoke();
        
        if (Input.GetMouseButtonDown(LeftMouseButton))
            AttackPressed?.Invoke();

        var movement = Input.GetAxis(HorizontalAxis); 
        MovementPressed?.Invoke(movement);
    }
}
