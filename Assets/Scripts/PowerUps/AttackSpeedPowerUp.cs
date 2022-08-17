using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Powerups/AttackSpeedBuff"))]
public class AttackSpeedPowerUp : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Shooting>().fireRate += amount;


    }
}
