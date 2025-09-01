using UnityEngine;

public class MovementFB : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotateUpSpeed;
    [SerializeField] private float _rotateDownSpeed;
    [SerializeField] private float _horizontalSpeed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _horizontalSpeed * Time.deltaTime * Vector3.right;
    }

    private void Update()
    {
        if (_rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 20), _rotateUpSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -90), _rotateDownSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        _rb.velocity = Vector2.up * _jumpForce;
    }
}
