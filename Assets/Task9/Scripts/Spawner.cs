using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform[] _spawnPoints;

    private bool _canSpawn;

    private float _spawnTimer;

    private void Start()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints = gameObject.GetComponentsInChildren<Transform>();
        }
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
    }
}
