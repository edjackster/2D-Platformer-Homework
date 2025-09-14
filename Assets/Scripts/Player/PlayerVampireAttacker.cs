using System;
using System.Collections;
using UnityEngine;

public class PlayerVampireAttacker : PeriodicAttacker
{
    [SerializeField] private float _attackCoolDown = 4;
    [SerializeField] private float _attackDuration = 6;
    [SerializeField] private float _vampirismPercent = .5f;
    [SerializeField] private VampireAura _aura;
    [SerializeField] private HealthSystem _health;

    private bool _canAttack = true;

    public event Action AttackStarted;
    public event Action AttackEnded;

    public void Attack()
    {
        if (_canAttack == false)
            return;

        _canAttack = false;
        AttackStarted?.Invoke();

        StartCoroutine(UseVampirePowers());
    }

    private IEnumerator UseVampirePowers()
    {
        var wait = new WaitForSeconds(Tick);
        int stepsCount = Mathf.CeilToInt(_attackDuration / Tick);
        
        HealthSystem damagable;
        
        for (int i = 0; i < stepsCount; i++)
        {
            if(_aura.TryGetNearestEnemy(out damagable))
            {
                Attack(damagable);
                _health.Heal(Damage *  _vampirismPercent);
            }
            
            yield return wait;
        }

        AttackEnded?.Invoke();
        StartCoroutine(WaitCoolDown());
    }

    private IEnumerator WaitCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDown);
        _canAttack = true;
    }
}