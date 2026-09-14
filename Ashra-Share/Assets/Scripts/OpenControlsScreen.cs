using UnityEngine;
using UnityEngine.InputSystem;

public class OpenControlsScreen : MonoBehaviour
{
    public GameObject openControlsScreen;

    private Transform player;

    public UIManager uIManager;

    void Start()
    {
        uIManager = GetComponent<UIManager>();
        openControlsScreen.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame) 
        {
            OpenCtrlScreen();
        }
    }

    public void OpenCtrlScreen()
    {
        if (!uIManager.uiMenuOpen)
        {
            openControlsScreen.SetActive(true);
            Time.timeScale = 0f;

            uIManager.CheckMenuOpen();
            /*if (menuOpen = true)
            {
                Time.timeScale = 0f;
            }
            else if (menuOpen = false)
            {
                Time.timeScale = 1f;
            }*/
        }

    }
}