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
    public GameObject projectileDaggers;

    //Player Weapon Choices
    public enum weaponSelector
    {
        Default, 
        Homing,
        Spinning,
        Daggers,
    }
    [Header("Weapons")]
    public weaponSelector currentWeapon;

    //Variables
    [Header("Modifiers")]
    public int damage = 1;
    public float fireRate = 1f;
    public float bulletForce = 20f;
    //Not yet implemented
    public float projectileSize = 1f;
    public float range = 1f;

    //Base Stats
    private int baseDamage = 1;
    private float baseFireRate = 1f;
    private float baseBulletForce = 20f;
    private float baseProjectileSize = 1f;
    private float baseRange = 1f;
    
    
    //[HideInInspector]
    //Calculations
    public int totalDamage;
    public float totalFireRate;
    public float totalBulletForce;
    public float totalProjectileSize;
    public float totalRange; //This is just the time that projectile is on screen for.
    
    

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

        //Set current weapon to default
        //currentWeapon = weaponSelector.Default;

        //Only use this one for debugging.
        ProjectileSelector(currentWeapon);

    }

    // Update is called once per frame
    private void Update()
    {

        //Check what weapon is currently selected.
        ProjectileSelector(currentWeapon);


        //Shooting
        if (Input.GetButton("Fire1") & Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / (totalFireRate);
            Shoot();
        }

        

    }

    private void FixedUpdate()
    {
        //Calculations
        totalDamage = baseDamage + damage;
        totalFireRate = baseFireRate + fireRate;
        totalBulletForce = baseBulletForce + bulletForce;


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

            case (weaponSelector.Daggers):
                currentProjectile = projectileDaggers;
                baseFireRate = 2.5f;
                baseDamage = 0;
                break;
            
        }
    }
}
