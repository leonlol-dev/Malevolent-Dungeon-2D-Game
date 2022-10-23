using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Objects to set
    [Header("Things to set")]
    public Transform origin;
    public Transform origin2;
    public Transform origin3;
    public Camera cam;
    public AudioSource aSource;
    public GameObject player;
    public float itemRadius;

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

    [Header("Current Weapon Configuration")]

    //Player Weapon Choices

    //public enum weaponSelector
    //{
    //    Default, 
    //    Homing,
    //    Spinning,
    //    Daggers,
    //    Skull
    //}
    //[Header("Weapons")]
    //public weaponSelector currentWeapon;
    //private weaponSelector prevWeapon;

    public Weapon weapon;
    public GameObject weaponItemPrefab;
    public GameObject currentProjectile;

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
    public bool canFire;

    //IDS
    // default = 0
    // homing = 1
    // spinning axe = 2
    // daggers = 3
    // skull = 4
    // sickle = 5


    //Base Stats
    public int baseDamage = 1;
    public float baseFireRate = 1f;
    public float baseBulletForce = 20f;
    public float baseProjectileSize = 1f;
    public float baseRange = 1f;

    
    [Header("Total Calculations")]
    //[HideInInspector]
    //Calculations
    public int totalDamage;
    public float totalFireRate;
    public float totalBulletForce;
    public float totalProjectileSize;
    public float totalRange;

    [Header("Sounds")]
    public AudioClip attackSound;


   

    //Private
    private float nextTimeToFire = 0f;
    private CircleCollider2D circleCollider;
    public GameObject currentItemHover;


   
   

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();

        //Only use this one for debugging.
        //ProjectileSelector(currentWeapon);
        weapon.Equip(player);

        //Calculate base stats + modifiers at the start of the game
        CalculateTotal();

        //Player can fire when instantiated into the world.
        canFire = true;

    }

    // Update is called once per frame
    private void Update()
    {

        //Shooting
        if (canFire && Input.GetButton("Fire1") & Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / (totalFireRate);
            Shoot();
        }



        //===================================================================================
        //Any further updates to this script make sure to do it above these if statements.
        //This checks if the player is hovering over an item and will return back to the top
        //if there isn't.
        //===================================================================================

        if (currentItemHover == null)
        {
            return;
        }

        //Picking Up a Weapon and destroys the world item.
        if (Input.GetKeyDown(KeyCode.E) && currentItemHover.GetComponent<WeaponItem>().playerInProximity)
        {
            player.GetComponent<PlayerAudioHandler>().pickUpSound(true);
            PickUpWeapon(currentItemHover.GetComponent<WeaponItem>().weapon);
            Destroy(currentItemHover);
        }

        //If cannot pick up weapon then plays a reject sound.
        else if (Input.GetKeyDown(KeyCode.E) && currentItemHover.GetComponent<WeaponItem>().playerInProximity)
        {

            //Play Reject clip
            player.GetComponent<PlayerAudioHandler>().pickUpSound(false);
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

        //Get projectile from the object pool and apply force to projectile.
        ShootProjectile(origin);

        // If the current weapon id is dagger, shoot multiple.
        if(id == 3)
        {
            ShootProjectile(origin2);
            ShootProjectile(origin3);
        }
        
    }

    public void PickUpWeapon(Weapon _weapon)
    {
        if(weapon != null)
        {
 
            Instantiate(weaponItemPrefab, origin.transform.position, transform.rotation);
        }

        _weapon.Equip(this.gameObject);

    }


    //public void ProjectileSelector(weaponSelector _currentWeapon)
    //{
        

    //    switch (_currentWeapon)
    //    {
    //        default:
    //            Debug.Log("Couldn't switch weapons, going to default weapon!");
    //            currentProjectile = projectileHomingPrefab;
    //            attackSound = swordSound;
    //            baseFireRate = 3f;
    //            baseDamage = 1;
    //            baseBulletForce = 20f;
    //            baseProjectileSize = 3f;
    //            break;

    //        case (weaponSelector.Default):
    //            id = 0;
    //            currentProjectile = projectilePrefab;
    //            attackSound = swordSound;
    //            baseFireRate = 3f;
    //            baseDamage = 2;
    //            baseBulletForce = 20f;
    //            baseProjectileSize = 4f;
    //            break;

    //        case (weaponSelector.Homing):
    //            id = 1;
    //            currentProjectile = projectileHomingPrefab;
    //            attackSound = swordSound;
    //            baseFireRate = 3f;
    //            baseDamage = 2;
    //            baseBulletForce = 5f;
    //            baseProjectileSize = 4f;
    //            break;

    //        case (weaponSelector.Spinning):
    //            id = 2;
    //            currentProjectile = projectileAxe;
    //            attackSound = swordSound;
    //            baseFireRate = 1.5f;
    //            baseDamage = 5;
    //            baseBulletForce = 10f;
    //            baseProjectileSize = 6f;
    //            break;

    //        case (weaponSelector.Daggers):
    //            id = 3;
    //            currentProjectile = projectileDaggers;
    //            attackSound = swordSound;
    //            baseFireRate = 4.5f;
    //            baseDamage = 1;
    //            baseBulletForce = 20f;
    //            baseProjectileSize = 3f;
    //            break;

    //        case (weaponSelector.Skull):
    //            id = 4;
    //            currentProjectile = projectileSkull;
    //            attackSound = skullSound;
    //            baseFireRate = 2f;
    //            baseDamage = 3;
    //            baseBulletForce = 5f;
    //            baseProjectileSize = 2f;
    //            break;


    //    }

        
    //}
    
    public void CalculateTotal()
    {
        //Calculations
        totalDamage = baseDamage + damage;
        totalFireRate = baseFireRate + fireRate;
        totalBulletForce = baseBulletForce + bulletForce;
        totalProjectileSize = baseProjectileSize + projectileSize;
        totalRange = baseRange + range;
    }

    public void ShootProjectile(Transform _origin)
    {
        GameObject sword = Pool.Instance.Activate(id, _origin.position, _origin.rotation);
        sword.transform.localScale = new Vector3(totalProjectileSize, totalProjectileSize, 0);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.AddForce(_origin.up * totalBulletForce, ForceMode2D.Impulse);
    }


    //This is in it's own game object now
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Item" && collision.gameObject.GetComponent("WeaponItem") as WeaponItem != null)
    //    {
    //        currentItemHover = collision.gameObject;
    //    }
    //}
}
