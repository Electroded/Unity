using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _reloadTime;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _shootPoint;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    IEnumerator _shootingWorker()
    {
        while (true)
        {
            Vector3 direction = (_shootPoint.position - transform.position).normalized;

            Rigidbody NewBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            NewBullet.transform.up = direction;

            NewBullet.velocity = direction * _force;

            yield return new WaitForSeconds(_reloadTime);
        }
    }
}