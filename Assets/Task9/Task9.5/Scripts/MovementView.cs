using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MovementView : MonoBehaviour
{
    private const string Hit = "Hit";
    private const string Speed = "Speed";
    private const string Attack = "Attack";

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetSpeed(float horizontalInput)
    {
        _animator.SetFloat(Speed, Mathf.Abs(horizontalInput));
    }

    public void FlipX(float horizontalInput)
    {
        _spriteRenderer.flipX = horizontalInput > 0f;
    }

    public void HitAnimation()
    {
        _animator.SetTrigger(Hit);
    }
    public void AttackAnimation()
    {
        _animator.SetTrigger(Attack);
    }
}
