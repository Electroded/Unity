using UnityEngine;
using DG.Tweening;
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed, _duration;
    private void Update()
    {
        transform.DOMoveZ(_speed, _duration);
    }
}
