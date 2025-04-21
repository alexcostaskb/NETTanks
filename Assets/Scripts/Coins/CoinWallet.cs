using Unity.Netcode;
using UnityEngine;

public class CoinWallet : NetworkBehaviour
{
    public NetworkVariable<int> TotalCoins = new NetworkVariable<int>();

    public void SpendCoins(int costToFire)
    {
        TotalCoins.Value -= costToFire;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out Coin coin))
        {
            return;
        }

        int coinValue = coin.Collect();

        if (!IsServer)
        {
            return;
        }

        TotalCoins.Value += coinValue;
    }
}