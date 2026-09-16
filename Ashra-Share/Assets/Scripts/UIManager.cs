using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool uiMenuOpen;

    public GameObject craftMenu, shopMenu, ctrlMenu, localMapMenu, islandMapMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckMenuOpen()
    {
        if (!craftMenu.activeInHierarchy)
        {
            if (!shopMenu.activeInHierarchy)
            {
                if (!ctrlMenu.activeInHierarchy)
                {
                    if (!localMapMenu.activeInHierarchy)
                    {
                        if (!islandMapMenu.activeInHierarchy)
                        {
                            uiMenuOpen = false;
                            return;
                        }
                    }
                }
            }
        }
        uiMenuOpen = true;
    }
}
