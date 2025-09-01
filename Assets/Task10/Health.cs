using System;
public class Health
{
    public event Action<float> OnHealthChanged;

    private float _maxHealth;
    private float _currentHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public float CurrentHealth => _currentHealth;

    public float MaxHealth => _maxHealth;

    public void TakeDamage(float amount)
    {
        _currentHealth = Math.Max(_currentHealth - amount, 0);

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void Heal(float amount)
    {
        _currentHealth = Math.Min(_currentHealth + amount, _maxHealth);

        OnHealthChanged?.Invoke(_currentHealth);
    }
}