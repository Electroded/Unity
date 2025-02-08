using UnityEngine;

[RequireComponent (typeof(ColorChanger))]
public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private int _targetLayer;
    [SerializeField] private float _destroyTimerMin;
    [SerializeField] private float _destroyTimerMax;
    [SerializeField] private Renderer _renderer;

    private CubePool _cubePool;
    private ColorChanger _colorChanger;

    private void Start()
    {
        _cubePool = GameObject.FindGameObjectWithTag("CubePool").GetComponent<CubePool>();
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _targetLayer)
        {
            DestroyWithDelay();

            if (!_colorChanger._isColorChanged)
            {
                _colorChanger.ChangeColor();
            }
        }
    }

    private void OnDestroy()
    {
        if (_cubePool != null)
        {
            _cubePool.DeletePoolObject(gameObject);
        }
    }

    private void DestroyWithDelay()
    {
        float destroyTimer = Random.Range(_destroyTimerMin, _destroyTimerMax);
        Destroy(gameObject, destroyTimer);
    }
}
