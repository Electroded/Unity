using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _currentCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
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
