using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Special/Tank"))]
public class TankSpecial : SpecialAttack
{
    public string title = "Tank Special";
    public string description = "Player has 100 more health, moves and attacks 15% faster for a short duration.";

    PlayerHealth pHealthScript;
    public override void Special(GameObject player)
    {
        pHealthScript = player.GetComponent<PlayerHealth>();
        pHealthScript.maxHealth += 100;
        pHealthScript.RestoreHealth(100);
        
    }

    public override void Return(GameObject player)
    {
        
        
    }
}
