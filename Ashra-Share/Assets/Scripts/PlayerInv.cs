using TMPro;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public int coinAmt;
    public int wheatAmt;
    public int stoneAmt;
    public int woodAmt;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI wheatText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI woodText;

    void Start()
    {
        UpdateAllUI();
    }

    // Update is called once per frame
    public void AddItem(int amount, ItemType type)
    {
        switch (type)
        {
            case ItemType.Coin:
                coinAmt += amount;
                break;

            case ItemType.Wheat:
                wheatAmt += amount;
                break;

            case ItemType.Stone:
                stoneAmt += amount;
                break;
            case ItemType.Wood:
                woodAmt += amount;
                break;

            default:
                break;
        }

        UpdateUI(type);
    }

    void UpdateUI(ItemType type)
    {
        switch (type)
        {
            case ItemType.Coin:
                coinText.text = "Coins: " + coinAmt.ToString();
                break;

            case ItemType.Wheat:
                wheatText.text = "Wheat: " + wheatAmt.ToString();
                break;

            case ItemType.Stone:
                stoneText.text = "Stone: " + stoneAmt.ToString();
                break;
            case ItemType.Wood:
                woodText.text = "Wood: " + woodAmt.ToString();
                break;

            default:
                break;
        }
    }

    void UpdateAllUI()
    {
        coinText.text = "Coins: " + coinAmt.ToString();
        wheatText.text = "Wheat: " + wheatAmt.ToString();
        stoneText.text = "Stone: " + stoneAmt.ToString();
        woodText.text = "Wood: " + woodAmt.ToString();
    }

    public bool HasItem(int amount, ItemType type)
    {
        switch (type)
        {
            case ItemType.Coin:
                return coinAmt >= amount;

            case ItemType.Wheat:
                return wheatAmt >= amount;

            case ItemType.Stone:
                return stoneAmt >= amount;

            case ItemType.Wood:
                return woodAmt >= amount;

            default:
                return false;
        }
    }

    public void RemoveItem(int amount, ItemType type)
    {
        switch (type)
        {
            case ItemType.Coin:
                coinAmt -= amount;
                UpdateUI(type);
                break;

            case ItemType.Wheat:
                wheatAmt -= amount;
                UpdateUI(type);
                break;

            case ItemType.Stone:
                stoneAmt -= amount;
                UpdateUI(type);
                break;

            case ItemType.Wood:
                woodAmt -= amount;
                UpdateUI(type);
                break;

            default:
                break;
        }
    }
}
