using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HealthBarView _barView;
    [SerializeField] private HealthTextView _textView;

    private Health _health;

    private void Start()
    {
        _health = new Health(100f);

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        _textView.UpdateHealth(_health.CurrentHealth, _health.MaxHealth);
        _barView.SetHPBar(_health.CurrentHealth);
        _barView.SmoothSetHPBar(_health.CurrentHealth);
    }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
        UpdateHealthUI();
    }

    public void Heal(float amount)
    {
        _health.Heal(amount);
        UpdateHealthUI();
    }
}