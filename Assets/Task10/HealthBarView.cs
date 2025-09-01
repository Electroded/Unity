using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _duration = 0.5f;

    public void SetHPBar(float health)
    {
        if (_slider != null)
        {
            _slider.value = health;
        }
    }

    public void SmoothSetHPBar(float health)
    {
        if (_smoothSlider != null)
        {
            StartCoroutine(SmoothChange(health));
        }
    }

    private IEnumerator SmoothChange(float targetValue)
    {
        float startValue = _smoothSlider.value;

        float elapsed = 0f;

        while (elapsed < _duration)
        {
            elapsed += Time.deltaTime;

            _smoothSlider.value = Mathf.Lerp(startValue, targetValue, elapsed / _duration);

            yield return null;
        }
        _smoothSlider.value = targetValue;
    }
}