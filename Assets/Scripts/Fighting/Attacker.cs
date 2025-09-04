using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected int _damage;

    protected virtual void Attack(IDamagable damagable)
    {
        damagable.TakeDamage(_damage);
    }
}