using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float lerpTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(int heal)
    {
        currentHealth += heal;
        lerpTimer = 0f; 
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }
}
