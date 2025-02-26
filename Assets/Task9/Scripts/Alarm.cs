using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private const float _minStrength = 0f;
    [SerializeField] private const float _maxStrength = 1f;
    [SerializeField] private float _recoveryRate;

    [SerializeField] private AudioSource _audioSource;

    private float _currentStrength;

    private bool _strengthIncreasing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            _strengthIncreasing = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cube") && _currentStrength !=_maxStrength)
        {
            _currentStrength = Mathf.MoveTowards(_currentStrength, _maxStrength, _recoveryRate * Time.deltaTime);
            print(_currentStrength);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _strengthIncreasing = false;
    }

    private void Update()
    {
        _audioSource.volume = _currentStrength;
        print(_currentStrength);
        if (!_strengthIncreasing && _currentStrength > _minStrength)
        {
            _currentStrength = Mathf.MoveTowards(_currentStrength, _minStrength, _recoveryRate * Time.deltaTime);
        }
    }
}
