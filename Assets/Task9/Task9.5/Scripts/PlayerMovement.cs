using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    private const string HorizontalInput = "Horizontal";
    private const string JumpButton = "Jump";

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Attack _attack;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private MovementView _movementView;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _groundCheckRadius;

    private bool _isGrounded;
    private float _horizontalInput;

    private void Update()
    {
        GetInput();

        UpdateAnimator(_horizontalInput);

        Flip(_horizontalInput);
    }

    private void FixedUpdate()
    {
        CheckGround();

        Move();
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxisRaw(HorizontalInput);

        if (Input.GetButtonDown(JumpButton) && _isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb.velocity.y);
    }

    private void UpdateAnimator(float horizontalInput)
    {
        _movementView.SetSpeed(Mathf.Abs(horizontalInput));
    }

    private void Flip(float horizontalInput)
    {
        if (horizontalInput != 0f)
        {
            _movementView.FlipX(horizontalInput);
        }
    }
}
