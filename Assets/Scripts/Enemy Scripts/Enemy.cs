using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject healthBar;

    [Header("Sounds")]
    public AudioClip hitSound;
    public AudioClip deathSound;

   

    //Private
    private bool died;
    private EnemyHealth health;
    private AudioSource aSource;
    private BoxCollider2D bCollider;
    private SpriteRenderer spriteRenderer;
    private EnemyLoot enemyLoot;

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
        spriteRenderer.enabled = false;
        healthBar.active = false;
        bCollider.enabled = false;
        enemyLoot.DropLoot();
        aSource.PlayOneShot(deathSound);
        Destroy(this.gameObject, 3f);
    }
}
