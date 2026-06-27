using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _pointsSpawnCoins;

    private void Awake()
    {
        CreateCoins();
    }

    private void CreateCoins() 
    {
        foreach (Transform pointSpawnCoin in _pointsSpawnCoins) 
        {
            Coin newCoin = Instantiate(_coinPrefab, pointSpawnCoin.position, Quaternion.identity);
            newCoin.ResourcePicked += DestroyCoin;
        }
    }

    private void DestroyCoin(Coin coin) 
    {
        coin.ResourcePicked -= DestroyCoin;
        Destroy(coin.gameObject);
    }
}
