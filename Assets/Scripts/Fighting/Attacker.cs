using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] protected float Damage;
    
    protected virtual void Attack(IDamagable damagable)
    {
        damagable.TakeDamage(Damage);
    }
}