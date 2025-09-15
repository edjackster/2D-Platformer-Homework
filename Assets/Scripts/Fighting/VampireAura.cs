using System.Collections.Generic;
using UnityEngine;

public class VampireAura : MonoBehaviour
{
    private List<HealthSystem> _damagables = new();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out _) == false)
            return;

        if (other.TryGetComponent(out HealthSystem damagable) && _damagables.Contains(damagable) == false)
            _damagables.Add(damagable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out _) == false)
            return;

        if (other.TryGetComponent(out HealthSystem damagable))
            _damagables.Remove(damagable);
    }

    public bool TryGetNearestEnemy(out HealthSystem nearestDamagable)
    {
        nearestDamagable = null;

        if (_damagables.Count == 0)
            return false;

        int firstIndex = 0;
        nearestDamagable = _damagables[firstIndex];
        float nearestDistance = (transform.position - nearestDamagable.transform.position).sqrMagnitude;

        foreach (var damagable in _damagables)
        {
            float distance = (transform.position - damagable.transform.position).sqrMagnitude;

            if (nearestDistance < distance)
            {
                nearestDamagable = damagable;
                nearestDistance = (transform.position - nearestDamagable.transform.position).sqrMagnitude;
            }
        }

        return true;
    }
}
