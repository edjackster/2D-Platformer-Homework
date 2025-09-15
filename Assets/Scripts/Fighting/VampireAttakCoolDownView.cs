using UnityEngine;
using UnityEngine.UI;

public class VampireAttakCoolDownView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerVampireAttacker _vampireAttacker;
    
    private void OnEnable()
    {
        _vampireAttacker.AttackStay += OnCoolDownChange;
        _vampireAttacker.AttackCoolDown += OnCoolDownChange;
    }
    
    private void OnDisable()
    {
        _vampireAttacker.AttackStay -= OnCoolDownChange;
        _vampireAttacker.AttackCoolDown -= OnCoolDownChange;
    }
    
    private void OnCoolDownChange(float percent){
        _slider.value = percent;
    }
}
