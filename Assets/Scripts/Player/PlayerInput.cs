using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";
    
    public event Action JumpPressed;
    public event Action<float> MovementPressed;

    private void Update()
    {
        if (Input.GetButtonDown(JumpButton))
            JumpPressed?.Invoke();

        var movement = Input.GetAxis(HorizontalAxis); 
        MovementPressed?.Invoke(movement);
    }
}
