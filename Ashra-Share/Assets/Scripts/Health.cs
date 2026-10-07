using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int startHealth = 100;
    public int maxHealth = 200;
    public int currentHealth;

    public int damageModifier; //Value is added to the damage this entity takes. (damage + damageModifier).
                               //Eg. Shield totem makes this -12

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
        PlayerAttackUpdate PlayerAttackUpdate = GetComponent<PlayerAttackUpdate>(); 
        if (PlayerAttackUpdate != null && PlayerAttackUpdate.IsBlocking)
        {
            DamageTaken.Invoke();
            return;
        }
        
        currentHealth -= (damage + damageModifier);
        currentHealth = Mathf.Clamp(currentHealth, 0, startHealth);

        DamageTaken.Invoke();

        if (currentHealth <= 0)
        {
            Die.Invoke();
        }
    }
}
