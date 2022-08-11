using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform origin;
    public GameObject projectilePrefab;
    public Camera cam;
    public AudioSource aSource;
    public AudioClip attackSound;
    
   
    private float defaultBulletForce = 0.0f;
    public float bulletForce = 20f;

    private float defaultFireRate = 0.0f;
    public float fireRate = 15f;


    private float nextTimeToFire = 0f;

    private void Start()
    {
        //Set default attack variables
        defaultBulletForce = bulletForce;
        defaultFireRate = fireRate;
    }

    // Update is called once per frame
    private void Update()
    {

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
        GameObject sword = Instantiate(projectilePrefab, origin.position, origin.rotation);
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
