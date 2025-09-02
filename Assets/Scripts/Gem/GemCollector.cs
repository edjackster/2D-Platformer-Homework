using UnityEngine;

public class GemCollector : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Gem gem) == false)
            return;
        
        _playerScore.AddGem(gem);
        gem.Collect();
    }
}
