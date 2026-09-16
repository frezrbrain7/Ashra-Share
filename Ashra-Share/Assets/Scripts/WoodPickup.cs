using UnityEngine;

public class WoodPickup : MonoBehaviour
{
    public int minWoodValue = 2;
    public int maxWoodValue = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Something touched Wood: " + other.name);

        if (other.CompareTag("ItemPickup"))
        {
            Debug.Log("Player picked up Wheat!");

            PlayerWood playerWood =
                other.GetComponent<PlayerWood>();

            int randomWoodValue = Random.Range(minWoodValue, maxWoodValue + 1);

            if (playerWood != null)
            {
                playerWood.AddWood(randomWoodValue);
            }

            Destroy(gameObject);
        }
    }
}