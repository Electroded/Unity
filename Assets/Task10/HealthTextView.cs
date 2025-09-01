using TMPro;
using UnityEngine;

public class HealthTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    public void UpdateHealth(float current, float max)
    {
        if (_healthText != null)
        {
            _healthText.text = $"{current} / {max}";
        }
    }
}