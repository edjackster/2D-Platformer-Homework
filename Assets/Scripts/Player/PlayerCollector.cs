using UnityEngine;

public class PlayerCollector : MonoBehaviour, ICollector
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private HealthSystem healthSystem;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ICollactable collactable))
            collactable.Collect(this);
    }
    
    public void CollectGem(Gem gem)
    {
        _playerScore.AddGem(gem);
    }

    public void CollectHealPack(HealPack healPack)
    {
        healthSystem.Heal(healPack.HealAmount);
    }
}
