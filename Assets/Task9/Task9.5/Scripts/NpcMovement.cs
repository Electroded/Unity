using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _player;
    [SerializeField] private NpcRoot _npcRoot;
    [SerializeField] private NpcAttack _npcAttack;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _wallCheckDistance;
    [SerializeField] private float _playerChaseRadius;
    [SerializeField] private float _playerAttackRadius;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _distanceOffset;
    [SerializeField] private Transform _patrolPointA;
    [SerializeField] private Transform _patrolPointB;

    private bool _isGrounded;
    private float _distanceToPlayer;
    private Vector3 _patrolTarget;

    private void Start()
    {
        _patrolTarget = _patrolPointB.position;
    }

    private void Update()
    {
        GroundCheck();

        _distanceToPlayer = _npcRoot.GetDistanceToTarget();

        if (_isGrounded)
        {
            if (_distanceToPlayer > _playerChaseRadius)
            {
                Patrol();
            }
            else
            {
                Chase();
            }
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _patrolTarget, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _patrolTarget) < _distanceOffset)
        {
            if (_patrolTarget == _patrolPointA.transform.position)
            {
                _patrolTarget = _patrolPointB.transform.position;
            }
            else
            {
                _patrolTarget = _patrolPointA.position;
            }
        }
    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
    }
}