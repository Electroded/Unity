using UnityEngine;
using UnityEngine.AI;

public class EnemyMover9_2 : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    public Transform _targetTransform;

    private void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();

        //_targetTransform = GetComponent<EnemyTarget>().targetTransform;

        _navAgent.SetDestination(_targetTransform.position);
    }
}
