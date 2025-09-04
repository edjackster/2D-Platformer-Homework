using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamagable
{
    private const int MinHealthPoints = 0;
    
    [SerializeField] private int _maxHealthPoints = 100;
    [SerializeField] private int _healthPoints = 100;
    
    public event Action TookDamage;

    private void OnValidate()
    {
        if(_healthPoints>_maxHealthPoints)
            _healthPoints = _maxHealthPoints;
    }
    
    public void TakeDamage(int damage)
    {
        if(damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be negative.");
        
        TookDamage?.Invoke();
        _healthPoints = Mathf.Clamp(_healthPoints - damage, MinHealthPoints, _maxHealthPoints);
        print($"{name}: {_healthPoints}");
    }

    public void Heal(int heal)
    {
        if(heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal), "Healing cannot be negative.");
        
        _healthPoints = Mathf.Clamp(_healthPoints + heal, MinHealthPoints, _maxHealthPoints);
        print($"{name}: {_healthPoints}");
    }
}
