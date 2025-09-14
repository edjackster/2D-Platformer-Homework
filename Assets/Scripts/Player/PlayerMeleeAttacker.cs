using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttacker : Attacker
{
    [SerializeField] private float _attackCoolDown = 0.5f;
    [SerializeField] private float _attackRange = 1f;
    
    private bool _canAttack = true;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    public void Attack()
    {
        if (_canAttack == false)
            return;

        _canAttack = false;
        
        var damagables = GetAllDamagables();
        
        foreach (IDamagable damagable in damagables)
        {
            Attack(damagable);
        }

        StartCoroutine(WaitCoolDown());
    }

    private List<IDamagable> GetAllDamagables()
    {
        var hits = Physics2D.CircleCastAll(transform.position, _attackRange, Vector2.zero);

        var damagables = new List<IDamagable>();
        IDamagable damagable;
        
        foreach (var hit in hits)
        {
            if(hit.transform.TryGetComponent<Enemy>(out _) == false)
                continue;
            
            if (hit.transform.TryGetComponent(out damagable) && damagables.Contains(damagable) == false)
                damagables.Add(damagable);
        }
        
        return damagables;
    }
    
    private IEnumerator WaitCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDown);
        _canAttack = true;
    }
}
