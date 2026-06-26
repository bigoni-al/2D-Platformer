using UnityEngine;

public class Bag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.LaunchDestroy(coin);
        }
    }
}
