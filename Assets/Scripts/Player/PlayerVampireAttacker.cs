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
    public event Action<float> AttackStay;
    public event Action<float> AttackCoolDown;

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
            if (_aura.TryGetNearestEnemy(out damagable))
            {
                Attack(damagable);
                _health.Heal(Damage * _vampirismPercent);
            }

            AttackStay?.Invoke(1 - (float)i / stepsCount);
            yield return wait;
        }

        AttackEnded?.Invoke();
        StartCoroutine(WaitCoolDown());
    }

    private IEnumerator WaitCoolDown()
    {
        var wait = new WaitForSeconds(Tick);
        int stepsCount = Mathf.CeilToInt(_attackCoolDown / Tick);

        for (int i = 0; i < stepsCount; i++)
        {
            yield return wait;
            AttackCoolDown?.Invoke((float)i / stepsCount);
        }

        AttackCoolDown?.Invoke(1);
        _canAttack = true;
    }
}