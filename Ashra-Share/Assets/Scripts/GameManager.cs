using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int banditsRemaining;
    public PlayerHealth playerHealth;

    public GameObject winScreen;
    public GameObject startScreen;
    public GameObject startScreen2;
    public GameObject controlsScreen;
    public GameObject localMap;
    public GameObject islandMap;
    public GameObject craftingMenu;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        banditsRemaining =
            GameObject.FindGameObjectsWithTag("Enemy").Length;
        playerHealth.setBanditsRemaining(banditsRemaining);

        //Debug.Log("Bandits at start: " + banditsRemaining);

        winScreen.SetActive(false);
        startScreen.SetActive(true);
        startScreen2.SetActive(false);
        controlsScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void BanditKilled()
    {
        banditsRemaining--;

        playerHealth.setBanditsRemaining(banditsRemaining);

        //Debug.Log("Bandits remaining: " + banditsRemaining);

        if (banditsRemaining <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        //Debug.Log("YOU WIN!");

        winScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void CloseWinScreen()
    {
        winScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CloseStartScreen()
    {
        startScreen.SetActive(false);
        startScreen2.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseStartScreen2()
    {
        startScreen2.SetActive(false);
        controlsScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseControlsScreen()
    {
        localMap.SetActive(false);
        islandMap.SetActive(false); 
        craftingMenu.SetActive(false);
        controlsScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SwitchToIslandMap()
    {
        localMap.SetActive(false);
        islandMap.SetActive(true);
    }
    public void SwitchToLocalMap()
    {
        localMap.SetActive(true);
        islandMap.SetActive(false);
    }
    public void CloseMaps()
    {
        localMap.SetActive(false);
        islandMap.SetActive(false);
    }
}