using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Powerups/HealthBuff"))]
public class MaxHealthBuff : PowerUpEffect
{
    public float amount;
    public int cost;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().maxHealth += amount;
        target.GetComponent<PlayerHealth>().RestoreHealth((int)amount);
        
    }

    public override int getCost { get { return cost; } }
}
