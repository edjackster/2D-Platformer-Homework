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

        foreach (var damagable in _damagables)
        {
            if (nearestDamagable is null)
                nearestDamagable = damagable;

            float nearestDistance = Vector2.Distance(transform.position, nearestDamagable.transform.position);
            float distance = Vector2.Distance(transform.position, damagable.transform.position);

            if (nearestDistance < distance)
            {
                nearestDamagable = damagable;
            }
        }

        return true;
    }
}
