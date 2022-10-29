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
    public PlayerHealth pHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pHealth = player.GetComponent<PlayerHealth>();
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            HealPlayer();
        }
    }


    //This function is for when the player picks this up in the game world.
    public void HealPlayer()
    {

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

    //This function is for when the player buys a potion in the store.
    public void BuyHeal(GameObject _player)
    {
        //Play sound
        _player.GetComponent<PlayerAudioHandler>().potionConsumeSound();

        //Heal player
        _player.GetComponent<PlayerHealth>().currentHealth += health;

    }
}
