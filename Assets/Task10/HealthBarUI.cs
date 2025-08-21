using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _duration = 0.5f;

    public void SetHealth(int health)
    {
        SetHPBar(health);

        SetHPText(health);

        SmoothSetHPBar(health);
    }

    private void SetHPText(int health)
    {
        _text.text = (health + "/" + 100) .ToString();
    }

    private void SetHPBar(int health)
    {
        _slider.value = health;
    }

    private void SmoothSetHPBar(int health)
    {
        StartCoroutine(SmoothChange(health));
    }

    private IEnumerator SmoothChange(int targetValue)
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
