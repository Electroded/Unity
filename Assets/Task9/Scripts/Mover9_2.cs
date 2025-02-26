using UnityEngine;
using UnityEngine.AI;

public class Mover9_2 : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private Transform _targetTransform;

    private void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();

        _navAgent.SetDestination(_targetTransform.position);
    }

    public void SetTargetTransform(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }
}
