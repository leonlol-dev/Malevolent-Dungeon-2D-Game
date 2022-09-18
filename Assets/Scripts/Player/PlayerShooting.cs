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
    private weaponSelector prevWeapon;

    //Variables
    [Header("Modifiers")]
    public int damage;
    public float fireRate;
    public float bulletForce;
    public float projectileSize;
    //Not yet implemented
    public float range;

    [Header("Debug")]
    public int id;

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
    private float nextTimeToFire = 0f;
    private AudioClip attackSound;
    private GameObject currentProjectile;


   
   

    private void Start()
    {
        //Set current weapon to default
        //currentWeapon = weaponSelector.Default;

        //Only use this one for debugging.
        ProjectileSelector(currentWeapon);

        //Calculate base stats + modifiers at the start of the game
        CalculateTotal();

    }

    // Update is called once per frame
    private void Update()
    {

        if (currentWeapon != prevWeapon)
        {
            //Check what weapon is currently selected.
            ProjectileSelector(currentWeapon);

            prevWeapon = currentWeapon;
        }

        
      


        //Shooting
        if (Input.GetButton("Fire1") & Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / (totalFireRate);
            Shoot();
        }

        

    }

    private void FixedUpdate()
    {
        CalculateTotal();

    }

    private void Shoot()
    {
        //Play attack sound.
        aSource.PlayOneShot(attackSound);

        //Instantiate and apply force to projectile.
        //GameObject sword = Instantiate(currentProjectile, origin.position, origin.rotation);
        GameObject sword = Pool.Instance.Activate(id, origin.position, origin.rotation);
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
                baseFireRate = 3f;
                baseDamage = 1;
                baseBulletForce = 20f;
                baseProjectileSize = 3f;
                break;

            case (weaponSelector.Default):
                id = 0;
                currentProjectile = projectilePrefab;
                attackSound = swordSound;
                baseFireRate = 3f;
                baseDamage = 2;
                baseBulletForce = 20f;
                baseProjectileSize = 4f;
                break;

            case (weaponSelector.Homing):
                id = 1;
                currentProjectile = projectileHomingPrefab;
                attackSound = swordSound;
                baseFireRate = 3f;
                baseDamage = 2;
                baseBulletForce = 5f;
                baseProjectileSize = 4f;
                break;

            case (weaponSelector.Spinning):
                id = 2;
                currentProjectile = projectileAxe;
                attackSound = swordSound;
                baseFireRate = 1.5f;
                baseDamage = 5;
                baseBulletForce = 10f;
                baseProjectileSize = 6f;
                break;

            case (weaponSelector.Daggers):
                id = 3;
                currentProjectile = projectileDaggers;
                attackSound = swordSound;
                baseFireRate = 4.5f;
                baseDamage = 1;
                baseBulletForce = 20f;
                baseProjectileSize = 3f;
                break;

            case (weaponSelector.Skull):
                id = 4;
                currentProjectile = projectileSkull;
                attackSound = skullSound;
                baseFireRate = 2f;
                baseDamage = 3;
                baseBulletForce = 5f;
                baseProjectileSize = 2f;
                break;


        }

        
    }
    
    public void CalculateTotal()
    {
        //Calculations
        totalDamage = baseDamage + damage;
        totalFireRate = baseFireRate + fireRate;
        totalBulletForce = baseBulletForce + bulletForce;
        totalProjectileSize = baseProjectileSize + projectileSize;
    }
}
