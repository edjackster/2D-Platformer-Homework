using System;
using UnityEngine;

public class Gem : MonoBehaviour, ICollactable
{
    [field: SerializeField] public int Value { get; private set; }
    
    public event Action<Gem> GemCollected;

    public void Collect(ICollector collector)
    {
        collector.CollectGem(this);
        GemCollected?.Invoke(this);
    }
}
