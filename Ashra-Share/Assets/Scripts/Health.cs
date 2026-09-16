using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int startHealth = 100;
    public int maxHealth = 200;
    public int currentHealth;

    public UnityEvent Die;
    public UnityEvent DamageTaken;
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHealth);

        DamageTaken.Invoke();

        if (currentHealth <= 0)
        {
            Die.Invoke();
        }
    }
}
