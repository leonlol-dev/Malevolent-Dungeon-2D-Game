using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Not sure if to make this script the master script for all enemy endeavours but I'm not sure.

    [Header("Assign Game Objects")]
    public GameObject healthBar;
    public EnemyRadialAttack attackScript;

    [Header("Sounds")]
    public AudioClip hitSound;
    public AudioClip deathSound;


   

    //Private
    [HideInInspector]public bool died;
    private EnemyHealth health;
    private AudioSource aSource;
    private BoxCollider2D bCollider;
    private SpriteRenderer spriteRenderer;
    private EnemyLoot enemyLoot;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = this.gameObject.GetComponent<EnemyHealth>();
        aSource = this.gameObject.GetComponent<AudioSource>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        enemyLoot = this.gameObject.GetComponent<EnemyLoot>();
        bCollider = this.gameObject.GetComponent<BoxCollider2D>();

        
    }

    private void Update()
    {
        if (health.currentHealth <= 0 && !died)
        {
            died = true;  
            Die();
        }    
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile" )
        {
            Debug.Log("Demon Hit");
            aSource.PlayOneShot(hitSound);
            health.TakeDamage(player.GetComponent<PlayerShooting>().totalDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Demon Hit");
            aSource.PlayOneShot(hitSound);
            health.TakeDamage(player.GetComponent<PlayerShooting>().totalDamage);
        }
    }


    private void Die()
    {
        enemyLoot.DropLoot();
        player.GetComponent<PlayerAudioHandler>().playSound(deathSound);
        Destroy(this.gameObject);
    }
}
