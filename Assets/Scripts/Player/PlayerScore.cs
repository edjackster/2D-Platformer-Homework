using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }
    
    public event Action<int> OnScoreChanged;

    public void AddGem(Gem gem)
    {
        Score += gem.Value;
        OnScoreChanged?.Invoke(Score);
    }
}
