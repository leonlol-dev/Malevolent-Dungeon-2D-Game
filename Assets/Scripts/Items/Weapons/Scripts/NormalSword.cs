using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Weapons/Weapon"))]
public class NormalSword : Weapon
{
    public int id = 0;
    public float fireRate;
    public int damage;
    public float bulletForce;
    public float projectileSize;
    public float range;
    public AudioClip attackSound;
    public GameObject projectilePrefab;
    public GameObject itemPrefab;

    public override int getId { get { return id; } }
    public override float getBaseFireRate { get { return fireRate; } }
    public override int getBaseDamage { get { return damage; } }
    public override float getBaseBulletForce { get { return bulletForce; } }
    public override float getBaseProjectileSize { get { return projectileSize; } }
    public override float getBaseRange { get { return range; } }
    public override AudioClip getAttackSound { get { return attackSound; } }
    public override GameObject getProjectilePrefab { get { return projectilePrefab; } }
    public override GameObject getItemPrefab { get { return itemPrefab; } }

    public override void Equip(GameObject player)
    {
        player.GetComponent<PlayerShooting>().id = id;
        player.GetComponent<PlayerShooting>().baseFireRate = fireRate;
        player.GetComponent<PlayerShooting>().baseDamage = damage;
        player.GetComponent<PlayerShooting>().baseBulletForce = bulletForce;
        player.GetComponent<PlayerShooting>().baseProjectileSize = projectileSize;
        player.GetComponent<PlayerShooting>().baseRange = range;
        player.GetComponent<PlayerShooting>().attackSound = attackSound;
        player.GetComponent<PlayerShooting>().projectilePrefab = projectilePrefab;


    }
}
