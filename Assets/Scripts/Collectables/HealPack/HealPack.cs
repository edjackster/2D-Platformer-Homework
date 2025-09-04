using System;
using UnityEngine;

public class HealPack : MonoBehaviour, ICollactable
{
    [field: SerializeField] public int HealAmount { get; private set; }
    
    public event Action<HealPack> HealPackCollected;

    public void Collect(ICollector collector)
    {
        collector.CollectHealPack(this);
        HealPackCollected?.Invoke(this);
    }
}
