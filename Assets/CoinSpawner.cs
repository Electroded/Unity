using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnAreaMin;
    [SerializeField] private Vector2 _spawnAreaMax;

    [SerializeField] private GameObject _coinPrefab;

    [SerializeField] private float _spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(_spawnInterval);
            print("Spawn");
        }
    }

    private void SpawnCoin()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),Random.Range(_spawnAreaMin.y, _spawnAreaMax.y));
        Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
    }
}
