using DG.Tweening;
using UnityEngine;

public class ColorChangerDotween : MonoBehaviour
{
    [SerializeField] private float colorTimer;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        Material material = _renderer.material;

        material.DOColor(Color.red, colorTimer);
    }
}