using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Objects to set
    [Header("Things to set")]
    public Transform origin;
    public Camera cam;
    public AudioSource aSource;
    public AudioClip attackSound;

    //Weapons
    [Header("Prefabs to set")]
    public GameObject projectilePrefab;
    public GameObject projectileHomingPrefab;
    public GameObject projectileAxe;

    //Player Weapon Choices
    public enum weaponSelector
    {
        Default, 
        Homing,
        Spinning,
    }
    [Header("Weapons")]
    public weaponSelector currentWeapon;

    //Variables
    [Header("Modifiers")]
    public int damage = 1;
    public float fireRate = 1f;
    public float bulletForce = 20f;
    public float projectileSize = 1f;


    public int totalDamage;

    //Private
    private float defaultBulletForce = 0.0f;
    private float defaultFireRate = 0.0f;
    //Base Stats
    private float baseFireRate = 1f;
    private int baseDamage = 1;
    private float nextTimeToFire = 0f;
    private GameObject currentProjectile;

    private void Start()
    {
        //Set default attack variables
        defaultBulletForce = bulletForce;
        defaultFireRate = fireRate;

        //Set current weapon to default
        currentWeapon = weaponSelector.Default;
         
    }

    // Update is called once per frame
    private void Update()
    {

        //Check what weapon is currently selected.
        ProjectileSelector(currentWeapon);

        //Calculate total damage
        totalDamage = baseDamage + damage;


        //Shooting
        if (Input.GetButton("Fire1") & Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / (baseFireRate + fireRate);
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
    

    public void ProjectileSelector(weaponSelector _currentWeapon)
    {
        switch (_currentWeapon)
        {
            default:
                Debug.Log("Couldn't switch weapons, going to default weapon!");
                currentProjectile = projectileHomingPrefab;
                break;

            case (weaponSelector.Default):
                currentProjectile = projectilePrefab;
                baseFireRate = 2f;
                baseDamage = 1;
                break;

            case (weaponSelector.Homing):
                currentProjectile = projectileHomingPrefab;
                baseFireRate = 3f;
                baseDamage = 1;
                break;

            case (weaponSelector.Spinning):
                currentProjectile = projectileAxe;
                baseFireRate = 0.5f;
                baseDamage = 4;
                break;
            
        }
    }
}
