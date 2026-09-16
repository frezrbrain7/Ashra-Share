using UnityEngine;

public class CraftingRecipes : MonoBehaviour
{
    /*public PlayerWheat playerWheat;
    public PlayerStone playerStone;
    public PlayerWood playerWood;*/

    public PlayerHealth playerHealth;

    public PlayerInv playerInv;

    public void CraftBread()
    {
        int wheatCost = 10;
        int breadReward = 4;

        if(playerInv.HasItem(wheatCost, ItemType.Wheat))
        {
            playerInv.RemoveItem(wheatCost, ItemType.Wheat);
            playerHealth.AddBread(breadReward);

            Debug.Log("Crafted Bread!");
        }
        else
        {
            Debug.Log("Not enough wheat!");
        }

        /*if (playerWheat.HasWheat(wheatCost))
        {
            playerWheat.RemoveWheat(wheatCost);
            playerHealth.AddBread(breadReward);

            Debug.Log("Crafted Bread!");
        }
        else
        {
            Debug.Log("Not enough wheat!");
        }*/
    }

    public void CraftStoneSword()
    {
        Debug.Log("CraftStoneSword button pressed");
        
        int stoneCost = 25;
        int woodCost = 5;
        string stoneSwordReward = "Stone";

        if ((playerInv.HasItem(stoneCost, ItemType.Stone)) && (playerInv.HasItem(woodCost, ItemType.Wood)))
        {
            playerInv.RemoveItem(stoneCost, ItemType.Stone);
            playerInv.RemoveItem(woodCost, ItemType.Wood);
            playerHealth.AddStoneSword(stoneSwordReward);

            Debug.Log("Crafted a Stone Sword!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }

        /*if ((playerStone.HasStone(stoneCost)) && (playerWood.HasWood(woodCost)))
        {
            playerStone.RemoveStone(stoneCost);
            playerWood.RemoveWood(woodCost);
            playerHealth.AddStoneSword(stoneSwordReward);

            Debug.Log("Crafted a Stone Sword!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }*/
    }
}