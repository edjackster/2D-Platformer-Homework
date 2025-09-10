using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothSliderView : HealthView
{
    private const float StepDuration = .01f;

    [SerializeField] private float _changeDuration;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void UpdateView(int health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothUpdateSlider(health));
    }

    private IEnumerator SmoothUpdateSlider(int health)
    {
        var wait = new WaitForSeconds(StepDuration);
        var stepsCount = _changeDuration / StepDuration;
        var sliderEndValue = (float)health / HealthSystem.MaxHealthPoints;
        var step = Math.Abs((sliderEndValue - _slider.value) / stepsCount);

        for (var i = 0; i < stepsCount; i++)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, sliderEndValue, step);
            yield return wait;
        }
    }
}