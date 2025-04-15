using UnityEngine;

public class NpcMovement : Movement
{
    [SerializeField] protected float _wallCheckDistance;
    [SerializeField] protected Transform _wallCheck;

    protected int _direction = 1;
    protected override void Move()
    {
        GroundCheck();

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