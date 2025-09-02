using System;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }
    
    public event Action<Gem> GemCollected;

    public void Collect()
    {
        GemCollected?.Invoke(this);
    }
}
