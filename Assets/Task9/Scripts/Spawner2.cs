using System.Collections;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval;
    private GameObject _enemyPrefab;

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

        EnemyType enemyType = spawnPoint.GetComponent<EnemyType>();

        GameObject _enemyPrefab = enemyType.enemyPrefab;

        GameObject newEnemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        Mover9_2 enemyMover9_2 = newEnemy.GetComponent<Mover9_2>();

        EnemyTarget enemyTarget = spawnPoint.GetComponent<EnemyTarget>();

        //Mover9_2.SetTargetTransform(enemyTarget.transform);
    }
}