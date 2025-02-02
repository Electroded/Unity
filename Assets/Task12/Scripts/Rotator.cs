using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationDuration;
    [SerializeField] private Vector3 _rotationSpeed;
    private void Update()
    {
        transform.DORotate(_rotationSpeed, _rotationDuration);
    }
}
