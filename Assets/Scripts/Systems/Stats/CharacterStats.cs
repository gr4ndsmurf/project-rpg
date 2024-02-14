using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private int maxHealth = 100;
    public int currentHealth {  get; private set; }

    public Stat damage;
    public Stat defense;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // TEST TAKEDAMAGE
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(damage.GetValue());
            Debug.Log("Current Health= " + currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= defense.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Die in some way.
        // This method is meant to be overwritten.
        Debug.Log(transform.name + " died.");
    }
}
