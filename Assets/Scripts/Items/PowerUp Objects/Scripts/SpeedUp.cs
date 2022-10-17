using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Powerups/SpeedUp"))]
public class SpeedUp : PowerUpEffect
{
    public float amount;
    public int cost;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().moveSpeed += amount;
        
    }

    public override int getCost { get { return cost; } }
}
