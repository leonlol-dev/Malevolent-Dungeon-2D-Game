using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Powerups/AttackSpeedBuff"))]
public class AttackSpeedPowerUp : PowerUpEffect
{
    public float amount;
    public int cost;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerShooting>().fireRate += amount;


    }

    public override int getCost { get { return cost; } }
}
