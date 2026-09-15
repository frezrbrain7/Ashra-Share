using UnityEngine;

public class ShopTrades : MonoBehaviour
{
    /*public PlayerWheat playerWheat;
    public PlayerStone playerStone;
    public PlayerWood playerWood;
    public PlayerCoins playerCoins;*/

    public PlayerInv playerInv;

    public PlayerHealth playerHealth;

    public void PurchaseBread()
    {
        int coinCost = 10;
        int breadReward = 7;

        if (playerInv.HasItem(coinCost, ItemType.Coin))
        {
            playerInv.RemoveItem(coinCost, ItemType.Coin); 
            playerHealth.AddBread(breadReward);

            Debug.Log("Purchesed Bread");
        }
        else
        {
            Debug.Log("Not enough coin!");
        }
    }

    public void PurchaseStoneSword()
    {
        Debug.Log("PurchaseStoneSword button pressed");
        
        int coinCost = 18;
        string stoneSwordReward = "Stone";

        if (playerInv.HasItem(coinCost, ItemType.Coin)) 
        {
            playerInv.RemoveItem(coinCost, ItemType.Coin); 
            playerHealth.AddStoneSword(stoneSwordReward);

            Debug.Log("Crafted a Stone Sword!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }
    }

    public void PurchaseCoinFromWheat()
    {
        int wheatCost = 10;
        int coinReward = 14;

        if (playerInv.HasItem(wheatCost, ItemType.Wheat))
        {
            playerInv.RemoveItem(wheatCost, ItemType.Wheat);
            playerInv.AddItem(coinReward, ItemType.Coin);

            Debug.Log("Purchesed Coin from Wheat");
        }
        else
        {
            Debug.Log("Not enough wheat!");
        }
    }

    public void PurchaseCoinFromWood()
    {
        int woodCost = 10;
        int coinReward = 13;

        if (playerInv.HasItem(woodCost, ItemType.Wood))
        {
            playerInv.RemoveItem(woodCost, ItemType.Wood);
            playerInv.AddItem(coinReward, ItemType.Coin);

            Debug.Log("Purchesed Coin from Wood");
        }
        else
        {
            Debug.Log("Not enough wood!");
        }
    }

    public void PurchaseCoinFromStone()
    {
        int stoneCost = 10;
        int coinReward = 15;

        if (playerInv.HasItem(stoneCost, ItemType.Stone))
        {
            playerInv.RemoveItem(stoneCost, ItemType.Stone);
            playerInv.AddItem(coinReward, ItemType.Coin);

            Debug.Log("Purchesed Coin from Stone");
        }
        else
        {
            Debug.Log("Not enough stone!");
        }
    }
}