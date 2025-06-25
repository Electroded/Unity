using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private LayerMask _coinLayerMask;

    private int _currentCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _coinLayerMask) != 0)
        {
            AddCoin();

            Destroy(collision.gameObject);
        }
    }

    private void AddCoin()
    {
        _currentCoins++;
        
        print("Current Coins: " + _currentCoins);
    }
}
