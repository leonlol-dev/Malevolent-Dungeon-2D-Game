using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChortProjectileSpawner : MonoBehaviour
{
    public GameObject fireball;
    public Transform origin;
    public bool canFire;
    public float fireRate = 1f;
    public float bulletForce = 1f;
    public float bulletLifeTime = 0.25f;
    public int damage;

    private GameObject player;
    private float nextTimeToFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            SpawnProjectile();
            
            Debug.Log("FIRE");

        }
    }

    private void FixedUpdate()
    {
       

    }

    public void SpawnProjectile()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        GameObject instantiatedProjectile = Instantiate(fireball, transform.position, Quaternion.identity);
        instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = direction * bulletForce;
        instantiatedProjectile.GetComponent<EnemyProjectile>().lifeTime = bulletLifeTime;
        instantiatedProjectile.GetComponent<EnemyProjectile>().damage = damage;

        //Destroy(instantiatedProjectile, bulletLifeTime);
    }
}
