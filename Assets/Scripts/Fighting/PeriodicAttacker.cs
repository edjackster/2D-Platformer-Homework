using UnityEngine;

public class PeriodicAttacker : MonoBehaviour
{
    protected const float Tick = .01f;

    [SerializeField, Min(.01f)] protected float DamagePerSecond;

    protected float Damage;

    private void Awake()
    {
        Damage = DamagePerSecond * Tick;
    }
    
    protected virtual void Attack(IDamagable damagable)
    {
        damagable.TakeDamage(Damage);
    }
}