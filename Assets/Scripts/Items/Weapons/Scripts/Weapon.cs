using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public string weaponDescription;
    public int goldCost;
    public abstract int getId { get; }
    public abstract int getCost { get; }
    public abstract float getBaseFireRate { get; }
    public abstract int getBaseDamage { get; }
    public abstract float getBaseBulletForce { get; }
    public abstract float getBaseProjectileSize { get; }
    public abstract float getBaseRange { get; }
    public abstract AudioClip getAttackSound { get; }
    public abstract GameObject getProjectilePrefab { get; }
    public abstract GameObject getItemPrefab { get; }
    public abstract void Equip(GameObject player);

}
