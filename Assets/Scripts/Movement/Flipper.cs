using UnityEngine;

public class Flipper : MonoBehaviour
{   
    private Quaternion _forward = Quaternion.Euler(0, 0, 0);
    private Quaternion _backward = Quaternion.Euler(0, 180, 0);
    
    public void Flip(float direction)
    {
        if (direction > 0)
            transform.localRotation = _forward;
        if (direction < 0)
            transform.localRotation = _backward;
    }
}
