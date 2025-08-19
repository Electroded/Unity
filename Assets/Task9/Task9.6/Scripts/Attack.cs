using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private MovementView _movementView;

    private Collider2D[] results = new Collider2D[10];
    private float _nextAttackTime;

    public void PerformAttack()
    {   
        if (Time.time >= _nextAttackTime)
        { 
            _nextAttackTime = Time.time + _attackCooldown;

            _movementView.AttackAnimation();

            int count = Physics2D.OverlapCircleNonAlloc(transform.position, _attackDistance, results, _layer);

            for (int i = 0; i < count; i++)
            {
                Collider2D hit = results[i];

                if (hit.TryGetComponent(out Health health))
                {
                    health.ApplyDamage(_damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackDistance);
    }
}
