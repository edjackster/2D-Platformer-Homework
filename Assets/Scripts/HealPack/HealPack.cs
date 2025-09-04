using System;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    [field: SerializeField] public int HealAmount { get; private set; }
    
    public event Action<HealPack> HealPackCollected;

    public void Collect()
    {
        HealPackCollected?.Invoke(this);
    }
}
