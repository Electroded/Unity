using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    private int _arrayIndex;
    private float _maxDistance;
    private Transform _placePoint;
    private Transform[] _places;

    private void Start()
    {
        _places = new Transform[_placePoint.childCount];

        for (int i = 0; i < _placePoint.childCount; i++)
        {
            _places[i] = _placePoint.GetChild(i);
        }
    }

    private void Update()
    {
        var _pointNumber = _places[_arrayIndex];

        transform.position = Vector3.MoveTowards(transform.position, _pointNumber.position, _maxDistance * Time.deltaTime);

        if (transform.position == _pointNumber.position)
        {
            NextPosition();
        }
    }

    private Vector3 NextPosition()
    {
        _arrayIndex++;

        if (_arrayIndex == _places.Length)
        {
            _arrayIndex = 0;
        }

        Vector3 nextPosition = _places[_arrayIndex].transform.position;

        transform.forward = nextPosition - transform.position;

        return nextPosition;
    }
}