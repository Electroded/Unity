using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(MovementView))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _isNpc = false;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckDistance = 0.5f;

    private MovementView _movementView;
    private Rigidbody2D _rb;
    public bool _isGrounded;
    private float _horizontalInput;
    public bool _movingRight = false;

    private int _direction = 1;

    private void Start()
    {
        _movementView = GetComponent<MovementView>();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_isNpc)
        {
            PlayerMove();
        }
        else
        {
            NpcMove();
        }
    }

    private void Update()
    {
        if (!_isNpc)
        {
            GetInput();        
        }
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        UpdateAnimator();

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void UpdateAnimator()
    {
        _movementView.SetSpeed(_horizontalInput);
    }

    private void PlayerMove()
    {
        GroundCheck();

        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb.velocity.y);

        if (_rb.velocity.x != 0f)
        {
            _movementView.FlipX(_horizontalInput);
        }
    }

    private void NpcMove()
    {
        Vector2 raycastDirection = _direction == 1 ? Vector2.right : Vector2.left;

        RaycastHit2D wallInfo = Physics2D.Raycast(_wallCheck.position, raycastDirection, _wallCheckDistance, _groundLayer);
      
        GroundCheck();

        if (_isGrounded && wallInfo)
        {
            _movingRight = !_movingRight;

            _direction *= -1;

            print(_rb.velocity.x);

            _movementView.FlipX(_rb.velocity.x *-1);
        }

        _rb.velocity = _movingRight == true ? new Vector2(_moveSpeed, _rb.velocity.y) : new Vector2(-_moveSpeed, _rb.velocity.y);
    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}
