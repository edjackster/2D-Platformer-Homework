using TMPro;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected HealthSystem HealthSystem;

    private void OnEnable()
    {
        UpdateView(HealthSystem.HealthPoints);
        HealthSystem.HealthChanged += UpdateView;
    }

    private void OnDisable()
    {
        HealthSystem.HealthChanged -= UpdateView;
    }

    protected abstract void UpdateView(int health);
}
