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

    //Sounds to set
    [Header("Sounds")]
    public AudioClip skullSound;
    public AudioClip swordSound;

    //Weapons
    [Header("Prefabs to set")]
    public GameObject projectilePrefab;
    public GameObject projectileHomingPrefab;
    public GameObject projectileAxe;
    public GameObject projectileDaggers;
    public GameObject projectileSkull;

    //Player Weapon Choices
    public enum weaponSelector
    {
        Default, 
        Homing,
        Spinning,
        Daggers,
        Skull
    }
    [Header("Weapons")]
    public weaponSelector currentWeapon;

    //Variables
    [Header("Modifiers")]
    public int damage = 1;
    public float fireRate = 1f;
    public float bulletForce = 1f;
    public float projectileSize = 1f;


    //Base Stats
    private int baseDamage = 1;
    private float baseFireRate = 1f;
    private float baseBulletForce = 20f;
    private float baseProjectileSize = 1f;
    

    
    
    [Header("Total Calculations")]
    //[HideInInspector]
    //Calculations
    public int totalDamage;
    public float totalFireRate;
    public float totalBulletForce;
    public float totalProjectileSize;

    
    

    //Private
    private float defaultBulletForce = 0.0f;
    private float defaultFireRate = 0.0f;
    private float nextTimeToFire = 0f;
    private AudioClip attackSound;
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
        totalProjectileSize = baseProjectileSize + projectileSize;


    }

    private void Shoot()
    {
        //Play attack sound.
        aSource.PlayOneShot(attackSound);

        //Instantiate and apply force to projectile.
        GameObject sword = Instantiate(currentProjectile, origin.position, origin.rotation);
        sword.transform.localScale = new Vector3(totalProjectileSize, totalProjectileSize, 0);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.AddForce(origin.up * totalBulletForce, ForceMode2D.Impulse);
    }



    public void ProjectileSelector(weaponSelector _currentWeapon)
    {
        switch (_currentWeapon)
        {
            default:
                Debug.Log("Couldn't switch weapons, going to default weapon!");
                currentProjectile = projectileHomingPrefab;
                attackSound = swordSound;
                baseFireRate = 2f;
                baseDamage = 1;
                baseBulletForce = 20f;
                baseProjectileSize = 3f;
                break;

            case (weaponSelector.Default):
                currentProjectile = projectilePrefab;
                attackSound = swordSound;
                baseFireRate = 2f;
                baseDamage = 1;
                baseBulletForce = 20f;
                baseProjectileSize = 3f;
                break;

            case (weaponSelector.Homing):
                currentProjectile = projectileHomingPrefab;
                attackSound = swordSound;
                baseFireRate = 3f;
                baseDamage = 1;
                baseBulletForce = 5f;
                baseProjectileSize = 3f;
                break;

            case (weaponSelector.Spinning):
                currentProjectile = projectileAxe;
                attackSound = swordSound;
                baseFireRate = 0.5f;
                baseDamage = 4;
                baseBulletForce = 10f;
                baseProjectileSize = 5f;
                break;

            case (weaponSelector.Daggers):
                currentProjectile = projectileDaggers;
                attackSound = swordSound;
                baseFireRate = 2.5f;
                baseDamage = 0;
                baseBulletForce = 20f;
                baseProjectileSize = 2f;
                break;

            case (weaponSelector.Skull):
                currentProjectile = projectileSkull;
                attackSound = skullSound;
                baseFireRate = 1f;
                baseDamage = 4;
                baseBulletForce = 11f;
                baseProjectileSize = 1f;
                break;


        }
    }
}
