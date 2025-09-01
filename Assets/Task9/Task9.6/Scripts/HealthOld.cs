using UnityEngine;

public class HealthOld : MonoBehaviour
{
    [SerializeField] private float _health;
    //[SerializeField] private HealthBarController _healthBarController;
    [SerializeField] private LayerMask _healthPackLayerMask;
    [SerializeField] private MovementView _movementView;

    private void Start()
    {
        //_healthBarController.SetHealth(_health);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        //_healthBarController.SetHealth(_health);

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

    public void Heal(float healthPack)
    {
        _health += healthPack;

        //_healthBarController.SetHealth(_health);
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