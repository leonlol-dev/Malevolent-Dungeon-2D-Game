using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Powerups/DamageUp"))]

public class DamageUp : PowerUpEffect
{
    public int amount;
    public int cost;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerShooting>().damage += amount;

    }
    public override int getCost { get { return cost; } }
}
