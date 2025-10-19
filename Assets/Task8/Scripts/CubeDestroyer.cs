using System.Collections;
using UnityEngine;

[RequireComponent (typeof(ColorChanger))]
public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private int _targetLayer;
    [SerializeField] private float _destroyTimerMin;
    [SerializeField] private float _destroyTimerMax;
    [SerializeField] private Renderer _renderer;

    private UnityCubePool _unityCubePool;
    private ColorChanger _colorChanger;
    private bool _delayStarted;

    private void Start()
    {
        _unityCubePool = GameObject.FindGameObjectWithTag("UnityCubePool").GetComponent<UnityCubePool>();
        
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _targetLayer && !_delayStarted)
        {
            StartCoroutine(ReleaseDelay());

            if (!_colorChanger._isColorChanged)
            {
                _colorChanger.ChangeColor();
            }
        }
    }

    private IEnumerator ReleaseDelay()
    {
        _delayStarted = true;

        float destroyTimer = Random.Range(_destroyTimerMin, _destroyTimerMax);
        
        yield return new WaitForSeconds(destroyTimer);

        if (_unityCubePool != null)
        {
            _unityCubePool.ReleasePoolObject(gameObject);
        }
    }
}