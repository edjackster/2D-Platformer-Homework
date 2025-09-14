using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamagable
{
    private const int MinHealthPoints = 0;

    [field: SerializeField] public float MaxHealthPoints { get; private set; }
    [field: SerializeField] public float HealthPoints { get; private set; }

    public event Action<float> HealthChanged;
    public event Action TookDamage;

    private void OnValidate()
    {
        if (HealthPoints > MaxHealthPoints)
            HealthPoints = MaxHealthPoints;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be negative.");

        HealthPoints = Mathf.Clamp(HealthPoints - damage, MinHealthPoints, MaxHealthPoints);
        HealthChanged?.Invoke(HealthPoints);
        TookDamage?.Invoke();
    }

    public void Heal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal), "Healing cannot be negative.");

        HealthPoints = Mathf.Clamp(HealthPoints + heal, MinHealthPoints, MaxHealthPoints);
        HealthChanged?.Invoke(HealthPoints);
    }
}