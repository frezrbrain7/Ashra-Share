using UnityEngine;
using UnityEngine.InputSystem;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject shopMenuClosed;
    public float openShopRadius = 10f;
    public GameObject shopPrompt;

    public UIManager uIManager;

    //public GameObject shopBtn;

    private bool menuOpen = false;
    private bool shopOpen = false;
    private Transform shop;
    public Transform playerTransform;

    void Start()
    {
        uIManager = GetComponent<UIManager>();

        shopMenu.SetActive(false);
        shopMenuClosed.SetActive(false);
        shop = GameObject.FindGameObjectWithTag("Shop").transform;
    }

    void Update()
    {
        float distanceToShop =
            Vector2.Distance(playerTransform.position, shop.position);

        bool playerNearShop =
            distanceToShop <= openShopRadius;

        shopPrompt.SetActive(playerNearShop);
        //shopBtn.SetActive(playerNearShop);

        if (!playerNearShop)
        {
            menuOpen = false;
            shopMenu.SetActive(false);
            shopMenuClosed.SetActive(false);
            uIManager.CheckMenuOpen();
            //Set shop button to active
        }

        if (Keyboard.current.tKey.wasPressedThisFrame && playerNearShop)
        {
            ToggleShopMenu();
        }
    }
    public void RepairShop(bool repairedShopStatus)
    {
        shopOpen = true;
        shopMenu.SetActive(true);
        shopMenuClosed.SetActive(false);

    }

    public void ToggleShopMenu()
    {
        if (!uIManager.uiMenuOpen)
        {
            if (shopOpen)
            {
                menuOpen = !menuOpen;
                shopMenu.SetActive(menuOpen);
            }
            else
            {
                menuOpen = !menuOpen;
                shopMenuClosed.SetActive(menuOpen);
            }
        }
        uIManager.CheckMenuOpen();
    }
}