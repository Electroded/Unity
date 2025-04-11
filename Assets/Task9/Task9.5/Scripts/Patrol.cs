using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private float wallCheckDistance = 0.5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool movingRight = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        RaycastHit2D wallInfo = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, groundLayer);

        if (!isGrounded || wallInfo)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
