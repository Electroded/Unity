using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private LayerMask _healthPackLayerMask;

    private MovementView _movementView;

    private void Start()
    {
        _movementView = GetComponent<MovementView>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

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
