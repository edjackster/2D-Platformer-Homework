using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private PlayerDetector _detector;
    [SerializeField] private float _memoryDuration = 1f;
    
    private Coroutine _forgetting;
    
    [CanBeNull] public Transform CurrentTarget { get; private set; }

    private void OnEnable()
    {
        _detector.PlayerDetected += OnPlayerFound;
        _detector.PlayerLost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _detector.PlayerDetected -= OnPlayerFound;
        _detector.PlayerLost -= OnPlayerLost;
    }

    private void OnPlayerFound(Player player)
    {
        if(_forgetting != null)
            StopCoroutine(_forgetting);
        
        CurrentTarget = player.transform;
    }

    private void OnPlayerLost()
    {
        _forgetting = StartCoroutine(Forget());
    }

    private IEnumerator Forget()
    {
        yield return new WaitForSeconds(_memoryDuration);
        CurrentTarget = null;
    }
}
