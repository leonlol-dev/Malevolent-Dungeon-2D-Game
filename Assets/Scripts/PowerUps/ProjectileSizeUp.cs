using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = ("Powerups/ProjectileSize"))]

public class ProjectileSizeUp : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerShooting>().projectileSize += amount;
    }
}
