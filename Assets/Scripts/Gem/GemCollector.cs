using System;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    public event Action<int> OnScoreChanged;
    
    public int Score { get; private set; }

    private void AddGem(Gem gem)
    {
        Score += gem.Value;
        OnScoreChanged?.Invoke(Score);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Gem>(out var gem) == false)
            return;
        
        AddGem(gem);
        Destroy(other.gameObject);
    }
}
