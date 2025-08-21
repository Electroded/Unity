using UnityEngine;

public class NpcAttack : MonoBehaviour
{
    [SerializeField] private IDistanceProvider distanceProvider;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private NpcRoot _npcRoot;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private MovementView _movementView;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _attackDistance = 1.5f;

    private Collider2D[] results = new Collider2D[10];
    private float _nextAttackTime;

    private void Update()
    {
        float distance = _npcRoot.GetDistanceToTarget();

        if (distance <= _attackDistance)
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
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
}
