using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] protected int _damage;

    public void Attack(IDamagable damagable)
    {
        damagable.TakeDamage(_damage);
    }
}