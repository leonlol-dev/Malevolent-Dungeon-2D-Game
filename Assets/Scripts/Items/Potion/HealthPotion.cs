using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public SpriteRenderer spriteRender;

    [Header("Declare these variables")]
    public int goldCost = 750;
    public int health = 50;

    //Private
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            HealPlayer();
        }
    }

    void HealPlayer()
    {
        PlayerHealth pHealth = player.GetComponent<PlayerHealth>();

        //If player current health isn't equal to the maxhealth. If it is do nothing.
        if (pHealth.currentHealth != pHealth.maxHealth)
        {
            //Play sound
            player.GetComponent<PlayerAudioHandler>().potionConsumeSound();

            //Heal player
            pHealth.currentHealth += health;

            //Destroy
            Destroy(this.gameObject);
        }
    }
}
