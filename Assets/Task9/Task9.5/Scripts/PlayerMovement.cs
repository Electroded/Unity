using UnityEngine;

public class PlayerMovement : Movement
{
    private const string HorizontalInput = "Horizontal";
    private const string JumpButton = "Jump";

    protected override void Update()
    {
        base.Update();
        GetInput();
    }

    protected void GetInput()
    {
        _horizontalInput = Input.GetAxisRaw(HorizontalInput);

        UpdateAnimator(_horizontalInput);

        if (Input.GetButtonDown(JumpButton) && _isGrounded)
        {
            Jump();
        }
    }

    protected override void Move()
    {
        GroundCheck();

        _rb.velocity = new Vector2(_horizontalInput * _moveSpeed, _rb.velocity.y);

        Flip(_horizontalInput);
    }
}
