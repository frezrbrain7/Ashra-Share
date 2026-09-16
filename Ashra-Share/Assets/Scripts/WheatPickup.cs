using UnityEngine;

public class WheatPickup : MonoBehaviour
{
    public int minWheatValue = 2;
    public int maxWheatValue = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Something touched wheat: " + other.name);

        if (other.CompareTag("ItemPickup"))
        {
            Debug.Log("Player picked up Wheat!");

            PlayerWheat playerWheat =
                other.GetComponent<PlayerWheat>();

            int randomWheatValue = Random.Range(minWheatValue, maxWheatValue + 1);

            if (playerWheat != null)
            {
                playerWheat.AddWheat(randomWheatValue);
            }

            Destroy(gameObject);
        }
    }
}