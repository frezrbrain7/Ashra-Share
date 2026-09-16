using UnityEngine;
using UnityEngine.InputSystem;

public class MapMenu : MonoBehaviour
{
    public GameObject localMap;
    public GameObject islandMap;

    public UIManager uIManager;


    void Start()
    {
        uIManager = GetComponent<UIManager>();

        localMap.SetActive(false);
        islandMap.SetActive(false);

        uIManager.CheckMenuOpen();
    }

    void Update()
    {
        if (!uIManager.uiMenuOpen)
        {
            if (Keyboard.current.lKey.wasPressedThisFrame)
            {
                localMap.SetActive(true);
                islandMap.SetActive(false);

                uIManager.CheckMenuOpen();
            }
            if (Keyboard.current.mKey.wasPressedThisFrame)
            {
                OpenMap();
                uIManager.CheckMenuOpen();
            }
        }
    }

    public void OpenMap()
    {
        islandMap.SetActive(true);
        localMap.SetActive(false);
    }
}