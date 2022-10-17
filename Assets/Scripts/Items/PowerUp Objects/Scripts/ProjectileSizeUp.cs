using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = ("Powerups/ProjectileSize"))]

public class ProjectileSizeUp : PowerUpEffect
{
    public float amount;
    public int cost;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerShooting>().projectileSize += amount;
    }

    public override int getCost { get { return cost; } }
}
