using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth health;
    public GameObject player;
    public AudioSource aSource;

    [Header("Sounds")]
    public AudioClip hitSound;
    public AudioClip deathSound;

    //Private
    private bool died;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = this.gameObject.GetComponent<EnemyHealth>();
        aSource = this.gameObject.GetComponent<AudioSource>();

        
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
            health.TakeDamage(player.GetComponent<PlayerShooting>().damage);
        }
    }

    private void Die()
    {
        aSource.PlayOneShot(deathSound);
        Destroy(this.gameObject, 0.25f);
    }
}
