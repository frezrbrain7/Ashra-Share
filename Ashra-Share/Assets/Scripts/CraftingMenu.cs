using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingMenu : MonoBehaviour
{
    public GameObject craftingMenu;

    public UIManager uIManager;

    private bool menuOpen = false;

    void Start()
    {
        uIManager = GetComponent<UIManager>();
        craftingMenu.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            ToggleCraftingMenu();
        }
    }

    public void ToggleCraftingMenu()
    {
        if (!uIManager.uiMenuOpen || menuOpen)
        {
            menuOpen = !menuOpen;

            craftingMenu.SetActive(menuOpen);

            uIManager.CheckMenuOpen();
        }
    }
}