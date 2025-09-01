using System;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public event Action JumpPressed;
    public event Action<float> MovementPressed;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            JumpPressed?.Invoke();

        var movement = Input.GetAxis("Horizontal"); 
        MovementPressed?.Invoke(movement);
    }
}
