using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _coins;

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
        _coins ++;
        
        print(_coins);
    }
}
