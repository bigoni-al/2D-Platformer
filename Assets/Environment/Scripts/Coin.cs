using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinPicked;

    public void LaunchDestroy(Coin coin) 
    {
        CoinPicked?.Invoke(coin);
    }
}
