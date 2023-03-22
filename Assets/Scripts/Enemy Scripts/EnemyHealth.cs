using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public EnemyHealthBarScript enemyHealth;

    [SerializeField] private SpriteRenderer spriteRend;
    void Start()
    {
        //Set current health to max at start.
        currentHealth = maxHealth;

        //Set slider/text UI
        enemyHealth.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(FlashRed());
        currentHealth -= damage;
        enemyHealth.SetHealth(currentHealth);
    }

    public IEnumerator FlashRed()
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = Color.white;
    }


}

