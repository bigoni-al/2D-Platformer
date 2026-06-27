using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    public event Action<Coin> ResourcePicked;

    public void ReportStatus() 
    {
        ResourcePicked?.Invoke(_coin);
    }
}
