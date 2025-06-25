using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;

    private float _nextAttackTime;

    private MovementView _movementView;

    private void Start()
    {
        _movementView = GetComponent<MovementView>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    public virtual void PerformAttack()
    {   
        if (Time.time >= _nextAttackTime)
        { 
            _nextAttackTime = Time.time + _attackCooldown;

            _movementView.AttackAnimation();

            Collider2D[] hitInfo = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _enemyLayer);

            foreach (Collider2D hit in hitInfo)
            {
                print(hit.name);

                Health health = hit.GetComponent<Health>();

                if (health != null)
                {
                    health.ApplyDamage(_damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}
