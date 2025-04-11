using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _coinLayer;

    private int _currentCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _coinLayer)
        {
            AddCoin();

            Destroy(collision.gameObject);
        }
    }

    private void AddCoin()
    {
        _currentCoins++;
        
        print(_currentCoins);
    }
}
