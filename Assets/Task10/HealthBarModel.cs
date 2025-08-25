using UnityEngine;

public class HealthBarModel : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }

    public void SetHealth(float value)
    {
        _health = Mathf.Clamp(value, 0, _maxHealth);
    }

    public void SetMaxHealth(float value)
    {
        _maxHealth = Mathf.Max(1f, value);

        _health = Mathf.Clamp(_health, 0, _maxHealth);
    }
}