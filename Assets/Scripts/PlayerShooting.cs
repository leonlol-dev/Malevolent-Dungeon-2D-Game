using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform origin;
    public GameObject projectilePrefab;
    public Camera cam;
    public AudioSource aSource;
    public AudioClip attackSound;
   
    //Variables
    [Header("Modifiers")]
    public int damage = 1;
    public float fireRate = 15f;
    public float bulletForce = 20f;

    //Specials
    [Header("Specials")]
    public bool homing = false;
    public GameObject projectileHomingPrefab;

    //Private
    private float defaultBulletForce = 0.0f;
    private float defaultFireRate = 0.0f;
    private float nextTimeToFire = 0f;
    private GameObject currentProjectile;

    private void Start()
    {
        //Set default attack variables
        defaultBulletForce = bulletForce;
        defaultFireRate = fireRate;

        //Set projectile
        if(homing)
        {
            currentProjectile = projectileHomingPrefab;
        }
        else
        {
            currentProjectile = projectilePrefab;
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Check if homing is enabled
        currentProjectile = projectilePrefab;

        if (homing)
        {
            currentProjectile = projectileHomingPrefab;
        }

        //Shooting
        if (Input.GetButton("Fire1") & Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        

    }

    private void Shoot()
    {
        //Play attack sound.
        aSource.PlayOneShot(attackSound);

        //Instantiate and apply force to projectile.
        GameObject sword = Instantiate(currentProjectile, origin.position, origin.rotation);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.AddForce(origin.up * bulletForce, ForceMode2D.Impulse);
    }


    // Methods to change variables
    public void SetBulletForce(float newBulletForce)
    {
        bulletForce = newBulletForce;
    }

    public void ResetBulletForce()
    {
        bulletForce = defaultBulletForce;
    }

    public void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }

    public void ResetFireRate()
    {
        fireRate = defaultFireRate;
    }
    


}
