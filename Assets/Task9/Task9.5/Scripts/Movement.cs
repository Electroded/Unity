using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Animator _animator;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private bool _facingRight = true;
    private float _horizontalInput;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(_horizontalInput));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }

        if (_horizontalInput < 0 && !_facingRight)
        {
            Flip();
        }
        else if (_horizontalInput > 0 && _facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb.velocity.y);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
