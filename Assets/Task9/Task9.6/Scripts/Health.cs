using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private HealthBarUI _healthBarUI;
    [SerializeField] private LayerMask _healthPackLayerMask;

    [SerializeField] private MovementView _movementView;

    private void Start()
    {
        _healthBarUI.SetHealth(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        _healthBarUI.SetHealth(_health);

        _movementView.HitAnimation();

        if (_health <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void Heal(int healthPack)
    {
        _health += healthPack;

        _healthBarUI.SetHealth(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _healthPackLayerMask) != 0)
        {
            Heal(collision.GetComponent<HealthPack>()._hpToHeal);
            Destroy(collision.gameObject);
        }
    }
}
