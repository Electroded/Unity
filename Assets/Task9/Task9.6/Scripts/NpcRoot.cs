using UnityEngine;

public class NpcRoot : MonoBehaviour, IDistanceProvider
{
    [SerializeField] private Transform _target;

    public float GetDistanceToTarget()
    {
        return Vector2.Distance(transform.position, _target.position);
    }

    public Transform Target => _target;
}
