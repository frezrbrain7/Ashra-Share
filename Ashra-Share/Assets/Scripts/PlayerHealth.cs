using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //public int startHealth = 100;
    //public int maxHealth = 200;
    //public int currentHealth;
    public TextMeshProUGUI healthText;
    public int maxNatRegenHealth = 120;
    public float natRegenTime = 5f;
    public float natRegenCooldown = 15f;

    public Health health;

    public int startingBread = 50;
    public int currentBread;
    public TextMeshProUGUI breadText;
    public float eatingCooldown = 0.5f;

    public GameObject deathScreen;

    public TextMeshProUGUI swordCheckText;
    public TextMeshProUGUI banditRemainingText;
    public string swordType = "Wood";
    private string currentSword;
    private int banditRemaining;

    private float nextEatTime = 0f;
    private float nextNatRegenTime = 5f;

    private Transform player;


    void Start()
    {
        deathScreen.SetActive(false);

        currentBread = startingBread;
        currentSword = "Wood";
        UpdateUI();
    }

    void Update()
    {
        if (Time.time >= nextNatRegenTime)
        {
            RegenHealth();
        }
        if ((Keyboard.current.eKey.isPressed) && (currentBread > 0) && (health.currentHealth <= health.maxHealth) && (Time.time >= nextEatTime))
        {
            nextEatTime =
                Time.time + eatingCooldown;
            EatBread();
        }
    }

    public bool HasStoneSword(string type)
    {
        return currentSword == type;
    }


    void RegenHealth()
    {
        if (health.currentHealth < maxNatRegenHealth) 
        {
            health.currentHealth += 1;
        }
        UpdateUI();

        nextNatRegenTime = Time.time + natRegenTime;

    }

    public void EatBread()
    {
        health.currentHealth = health.currentHealth + 2;
        currentBread = currentBread - 1;
        UpdateUI();
    }

    public void AddBread(int amount)
    {
        currentBread += amount;
        UpdateUI();
    }

    public void AddStoneSword(string type)
    {
        currentSword = type;
        UpdateUI();
    }

    public void TakeDamage()
    {
        nextNatRegenTime = Time.time + natRegenCooldown;

        UpdateUI();

        Debug.Log(gameObject.name + " took damage!");
    }

    public void setBanditsRemaining(int amount)
    {
        banditRemaining = amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health.currentHealth;
        breadText.text = "Bread: " + currentBread;
        swordCheckText.text = "Sword Type: " + currentSword;
        banditRemainingText.text = "Bandits Remaining: " + banditRemaining;
    }

    public void Die()
    {
        health.currentHealth = 0;
        UpdateUI();
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }
}
