using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(MovementView))]

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected bool _isNpc = false;
    [SerializeField] protected float _moveSpeed = 5f;
    [SerializeField] protected float _jumpForce = 10f;
    [SerializeField] protected float _groundCheckRadius;
    [SerializeField] protected Transform _groundCheck;
    [SerializeField] protected LayerMask _groundLayer;

    protected bool _isGrounded;
    protected bool _movingRight = false;
    protected float _horizontalInput;
    protected Rigidbody2D _rb;
    protected MovementView _movementView;

    protected virtual void Start()
    {
        _movementView = GetComponent<MovementView>();

        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Update()
    {
        
    }

    protected abstract void Move();

    protected virtual void GroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    protected virtual void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    protected virtual void UpdateAnimator(float horizontalInput)
    {
        _movementView.SetSpeed(Mathf.Abs(horizontalInput));
    }

    protected virtual void Flip(float horizontalInput)
    {
        if (horizontalInput != 0f)
        {
            _movementView.FlipX(horizontalInput);
        }
    }
}
