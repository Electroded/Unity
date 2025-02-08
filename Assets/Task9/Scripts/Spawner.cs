using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    { 
        int randomIndex = Random.Range(0, _spawnPoints.Length);

        Transform spawnPoint = _spawnPoints[randomIndex];

        GameObject newEnemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}