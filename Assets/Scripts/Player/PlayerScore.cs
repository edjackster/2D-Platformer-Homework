using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }
    

    public void AddGem(Gem gem)
    {
        Score += gem.Value;
    }
}
