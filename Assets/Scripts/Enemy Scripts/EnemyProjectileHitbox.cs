using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileHitbox : MonoBehaviour
{
    public EnemyProjectile projectile;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(projectile.damage);
            Destroy(projectile.gameObject);
        }
    }
}
