using UnityEngine;

public class RepairShop : MonoBehaviour
{
    /*public PlayerWheat playerWheat;
    public PlayerStone playerStone;
    public PlayerWood playerWood;*/

    public PlayerInv playerInv;

    public ShopMenu shopMenu;


    public void RepairShopButton()
    {
        Debug.Log("Repair button pressed");
        
        int wheatCost = 20;
        int stoneCost = 17;
        int woodCost = 15;
        bool repairedShopStatus = true;


        if((playerInv.HasItem(stoneCost, ItemType.Stone)) 
            && (playerInv.HasItem(woodCost, ItemType.Wood)) 
            && (playerInv.HasItem(wheatCost, ItemType.Wheat)))
        {
            playerInv.RemoveItem(wheatCost, ItemType.Wheat);
            playerInv.RemoveItem(stoneCost, ItemType.Stone);
            playerInv.RemoveItem(wheatCost, ItemType.Wheat);
            shopMenu.RepairShop(repairedShopStatus);

            Debug.Log("Repaired the Shop!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }


        /*if ((playerStone.HasStone(stoneCost)) && (playerWood.HasWood(woodCost)) && (playerWheat.HasWheat(wheatCost)))
        {
            playerWheat.RemoveWheat(wheatCost);
            playerStone.RemoveStone(stoneCost);
            playerWood.RemoveWood(woodCost);
            shopMenu.RepairShop(repairedShopStatus);

            Debug.Log("Repaired the Shop!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }*/
    }
}