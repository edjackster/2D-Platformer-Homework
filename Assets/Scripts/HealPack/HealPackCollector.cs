using UnityEngine;

public class HealPackCollector : MonoBehaviour
{
    [SerializeField] private Health _health;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out HealPack healPack) == false)
            return;
        
        _health.Heal(healPack.HealAmount);
        healPack.Collect();
    }
}
