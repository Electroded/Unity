using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _forceMagnitude = 10f;
    private int _numObjects;

    public void Explode()
    {
        print("Explode");

        InstantiateObjectsAroundTarget();

        Destroy(gameObject);
    }
    private void InstantiateObjectsAroundTarget()
    {
        _numObjects = Random.Range(2, 7);
        for (int i = 0; i < _numObjects; i++)
        {
            print(_numObjects);
            Vector3 randomPoint = Random.insideUnitCircle * _radius;
            Vector3 spawnPosition = transform.position + new Vector3(randomPoint.x, 0f, randomPoint.y);

            GameObject instance = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            
            if (instance.TryGetComponent<Rigidbody>(out var rb))
            {
                Vector3 direction = (instance.transform.position - transform.position).normalized;

                rb.AddForce(direction * _forceMagnitude, ForceMode.Impulse);

                instance.transform.localScale = Vector3.one / 2;

                instance.transform.rotation = Quaternion.identity;

                if (instance.TryGetComponent<Renderer>(out var renderer))
                {
                    renderer = instance.GetComponent<Renderer>();
                    renderer.material.color = Random.ColorHSV();
                }
            }
            else
            {
                Debug.LogError("Prefab must have a Rigidbody component!");
            }
            _numObjects /= 2;
        }
    }
}
