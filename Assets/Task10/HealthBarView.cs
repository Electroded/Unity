using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _duration = 0.5f;

    public void SetHPBar(float health)
    {
        _slider.value = health;
    }

    public void SetHPText(float health, float maxHealth)
    {
        _text.text = $"{health}/{maxHealth}";
    }

    public void SmoothSetHPBar(float health)
    {
        StartCoroutine(SmoothChange(health));
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