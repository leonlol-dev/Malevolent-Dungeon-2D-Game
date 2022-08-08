using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform origin;
    public GameObject projectilePrefab;
    public Camera cam;


    private float defaultBulletForce = 0.0f;
    public float bulletForce = 20f;

    private float defaultFireRate = 0.0f;
    public float fireRate = 15f;


    private float nextTimeToFire = 0f;

    private void Start()
    {
        defaultBulletForce = bulletForce;
        defaultFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") & Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        

    }

    void Shoot()
    {
        GameObject sword = Instantiate(projectilePrefab, origin.position, origin.rotation);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.AddForce(origin.up * bulletForce, ForceMode2D.Impulse);
    }


    // Methods to change variables
    void SetBulletForce(float newBulletForce)
    {
        bulletForce = newBulletForce;
    }

    void ResetBulletForce()
    {
        bulletForce = defaultBulletForce;
    }

    void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }

    void ResetFireRate()
    {
        fireRate = defaultFireRate;
    }
    

}
