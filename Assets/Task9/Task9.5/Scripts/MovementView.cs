using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MovementView : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float horizontalInput)
    {
        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    public void FlipX(float horizontalInput)
    {
        _spriteRenderer.flipX = horizontalInput > 0f;
    }
}
