using System;
using UnityEngine;

public class GemCollector : MonoBehaviour
{
    public event Action<int> OnScoreChanged;
    
    public int Score { get; private set; }

    public void AddGem(Gem gem)
    {
        Score += gem.Value;
        OnScoreChanged?.Invoke(Score);
    }
}
