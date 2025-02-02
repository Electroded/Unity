using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleTarget;
    [SerializeField] private float _scaleDuration;
    private void Update()
    {
        transform.DOScale(_scaleTarget, _scaleDuration);
    }
}
