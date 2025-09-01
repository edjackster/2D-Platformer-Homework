using UnityEngine;

public class Flipper : MonoBehaviour
{   
    public void Flip(float direction)
    {
        if (direction > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (direction < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
