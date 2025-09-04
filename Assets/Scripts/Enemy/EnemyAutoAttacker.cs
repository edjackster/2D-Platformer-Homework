using System.Collections;
using UnityEngine;

public class EnemyAutoAttacker : MonoBehaviour
{
    [SerializeField] private float _attackCoolDown = 0.5f;
    [SerializeField] private Attacker _attacker;
    
    private bool _canAttack = true;
    
    private void OnTriggerStay2D(Collider2D other)
    {   
        if (other.TryGetComponent<Player>(out _) == false)
            return;
        
        if (other.TryGetComponent(out IDamagable damagable) == false)
            return;
        
        Attack(damagable);
    }
    
    private IEnumerator WaitCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDown);
        _canAttack = true;
    }

    private void Attack(IDamagable damagable)
    {
        if (_canAttack == false)
            return;
        
        _canAttack = false;
        _attacker.Attack(damagable);
        StartCoroutine(WaitCoolDown());
    }
}
