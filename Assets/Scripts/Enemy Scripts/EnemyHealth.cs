using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public EnemyHealthBarScript enemyHealth;


    void Start()
    {
        //Set current health to max at start.
        currentHealth = maxHealth;

        //Set slider/text UI
        enemyHealth.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealth.SetHealth(currentHealth);
    }


}

