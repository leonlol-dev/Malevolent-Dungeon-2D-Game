using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform origin;
    public GameObject projectilePrefab;
    public Camera cam;

    public float bulletForce = 20f;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        

    }

    void Shoot()
    {
        GameObject sword = Instantiate(projectilePrefab, origin.position, origin.rotation);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.AddForce(origin.up * bulletForce, ForceMode2D.Impulse);
    }
}
