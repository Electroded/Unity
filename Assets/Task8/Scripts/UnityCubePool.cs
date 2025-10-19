using UnityEngine;
using UnityEngine.Pool;

public class UnityCubePool : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnHeight;
    [SerializeField] private int _poolSize;
    [SerializeField] private int _maxPoolSize;
    [SerializeField] private GameObject _prefab;

    private ObjectPool<GameObject> _pool;

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(CreatePooledItem, OnGet,
            OnRelease, OnDestroyPoolObject, true, _poolSize, _maxPoolSize);

        InitializePool();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = GetPooledObject();
            obj.transform.position = RandomPointInCircle(_spawnRadius);
        }
    }

    private GameObject CreatePooledItem()
    {
        Vector3 randomPosition = RandomPointInCircle(_spawnRadius);
        GameObject obj = Instantiate(_prefab, randomPosition, Quaternion.identity);
        obj.SetActive(false);
        return obj;
    }

    private void OnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ReleasePoolObject(GameObject obj)
    {
        _pool.Release(obj);
    }

    public void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

    private void InitializePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            CreatePooledItem();
        }
    }

    private GameObject GetPooledObject()
    {
        return _pool.Get();
    }

    private Vector3 RandomPointInCircle(float radius)
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        return new Vector3(randomPoint.x, _spawnHeight, randomPoint.y);
    }
}