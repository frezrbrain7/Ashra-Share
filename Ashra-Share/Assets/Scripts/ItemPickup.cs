using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int minValue = 1;
    public int maxValue = 5;

    public ItemType pickupType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemPickup"))
        {

            PlayerInv playerInv =
                collision.GetComponent<PlayerInv>();

            int randomCoinValue = Random.Range(minValue, maxValue);

            if (playerInv != null)
            {
                playerInv.AddItem(randomCoinValue, pickupType);
            }

            Destroy(gameObject);
        }
    }
}
