using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private const int MinHealth = 0;
    
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health = 100;
    
    public event Action TookDamage;
    
    public void TakeDamage(int damage)
    {
        TookDamage?.Invoke();
        _health = Mathf.Clamp(_health - Math.Abs(damage), MinHealth, _maxHealth);
        print($"{name}: {_health}");
    }

    public void Heal(int heal)
    {
        _health = Mathf.Clamp(_health + Math.Abs(heal), MinHealth, _maxHealth);
        print($"{name}: {_health}");
    }

    private void OnValidate()
    {
        if(_health>_maxHealth)
            _health = _maxHealth;
    }
}
