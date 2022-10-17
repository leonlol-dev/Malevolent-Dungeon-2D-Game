using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = ("Powerups/BulletForceUp"))]
public class BulletForceUp : PowerUpEffect
{
    public float amount;
    public int cost;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerShooting>().bulletForce += amount;
    }

    public override int getCost { get { return cost; } }
}
