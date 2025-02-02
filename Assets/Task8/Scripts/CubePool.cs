using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private int _poolSize;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnHeight;
    [SerializeField] private GameObject _pooledObjectPrefab;

    private List<GameObject> _pooledObjects;

    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        InitializePool();
    }

    private void Update()
    {
        int cubeNumber = _pooledObjects.Count;
        print(cubeNumber);
        while(_pooledObjects.Count < _poolSize)
        {
            CreateNewPooledObject();
        }     
    }
    private void InitializePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            CreateNewPooledObject();
        }
    }

    public void DeletePoolObject(GameObject obj)
    {
        print("Delete");
        _pooledObjects.Remove(obj);
    }
    private void CreateNewPooledObject()
    {
        Vector3 randomPosition = RandomPointInCircle(_spawnRadius);
        GameObject obj = Instantiate(_pooledObjectPrefab, randomPosition, Quaternion.identity);
        _pooledObjects.Add(obj);
    }

    private Vector3 RandomPointInCircle(float radius)
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        return new Vector3(randomPoint.x, _spawnHeight, randomPoint.y);
    }
}
