using UnityEngine;
using UnityEngine.Pool;

public class UnityCubePool : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnHeight;

    [SerializeField] private GameObject _prefab;

    [SerializeField] private int _poolSize;

    private ObjectPool<GameObject> _pool;

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool,
            OnReturnedToPool, OnDestroyPoolObject, true, _poolSize, _poolSize);

        InitializePool();
    }

    public GameObject CreatePooledItem()
    {
        Vector3 randomPosition = RandomPointInCircle(_spawnRadius);
        GameObject obj = Instantiate(_prefab, randomPosition, Quaternion.identity);
        obj.SetActive(false);
        return obj;
    }

    public void OnTakeFromPool(GameObject obj)
    {
        Vector3 randomPosition = RandomPointInCircle(_spawnRadius);
        obj.SetActive(true);
    }

    public void OnReturnedToPool(GameObject obj)
    {
        print("OI2");
        obj.SetActive(false);
        //_pool.Release(obj);
    }

    public void ReleasePooledObject(GameObject obj)
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

    private Vector3 RandomPointInCircle(float radius)
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        return new Vector3(randomPoint.x, _spawnHeight, randomPoint.y);
    }
}