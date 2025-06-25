using UnityEngine;

public class NpcMovement : Movement
{
    [SerializeField] protected Transform _wallCheck;
    [SerializeField] protected LayerMask _playerLayer;
    [SerializeField] protected float _wallCheckDistance;
    [SerializeField] protected float _playerCheckRadius;
    [SerializeField] protected float _playerAttackRadius;
    [SerializeField] protected NpcAttack _npcAttack;
    [SerializeField] private Transform _player;

    protected float _distanceToPlayer;
    protected int _direction = 1;

    protected override void FixedUpdate()
    {
        PlayerCheck();
        GroundCheck();
    }

    private void PlayerCheck()
    {
        _distanceToPlayer = Vector2.Distance(_player.position, gameObject.transform.position);
        
        print(_distanceToPlayer);

        if (_distanceToPlayer > _playerCheckRadius)
        {
            Move();
        }

        else if (_distanceToPlayer > _playerAttackRadius)
        {
            Chase();
        }
        else if (_distanceToPlayer < _playerAttackRadius)
        {
            _npcAttack.PerformAttack();
        }
    }

    private void Chase()
    {
        Vector3 target = _player.position;

        float xPosition = Mathf.MoveTowards(_rb.position.x, target.x, _moveSpeed * Time.fixedDeltaTime);

        Vector2 newPosition = new Vector2(xPosition, _rb.position.y);

        _rb.MovePosition(newPosition);

        Flip(newPosition.x);

    }

    protected override void Move()
    {
        Vector2 raycastDirection = _direction == 1 ? Vector2.right : Vector2.left;

        RaycastHit2D wallInfo = Physics2D.Raycast(_wallCheck.position, raycastDirection, _wallCheckDistance, _groundLayer);

        if (_isGrounded && wallInfo)
        {
            _direction *= -1;

            Flip(_direction);
        }

        _rb.velocity = new Vector2(_direction * _moveSpeed, _rb.velocity.y);

        UpdateAnimator(_direction);
    }
}