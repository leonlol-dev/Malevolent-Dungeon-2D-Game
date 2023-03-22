using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float lerpTimer;

    [SerializeField] private SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(FlashRed());
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

    public IEnumerator FlashRed()
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = Color.white;
    }
}
