using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int minCoinValue = 1;
    public int maxCoinValue = 5;

    public ItemType coinType = ItemType.Coin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Something touched coin: " + other.name);

        if (other.CompareTag("ItemPickup"))
        {
            Debug.Log("Player picked up coin!");

            PlayerCoins playerCoins =
                other.GetComponent<PlayerCoins>();

            int randomCoinValue = Random.Range(minCoinValue, maxCoinValue);

            if (playerCoins != null)
            {
                playerCoins.AddCoins(randomCoinValue);
            }

            Destroy(gameObject);
        }
    }
}

