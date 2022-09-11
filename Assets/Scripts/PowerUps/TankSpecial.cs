using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Special/Tank"))]
public class TankSpecial : SpecialAttack
{
    public string title = "Tank Special";
    public string description = "Player has 100 more health, 50% more attack speed and speed";
    public float cooldown = 1f;
    public float duration = 3f;

    PlayerHealth pHealthScript;
    PlayerShooting shootingScript;
    PlayerMovement movementScript;

    private float increasedSpeed;
    private float increasedAttackSpeed;

    public override float getCooldown { get { return cooldown; } }
    public override float getDuration { get { return duration; } }

    //This is what the special does.
    public override void Special(GameObject player)
    {
        //Get components at the start of the special then save it into a variable.
        pHealthScript = player.GetComponent<PlayerHealth>();
        shootingScript = player.GetComponent<PlayerShooting>();
        movementScript = player.GetComponent<PlayerMovement>();

        //Health
        pHealthScript.maxHealth += 100;
        pHealthScript.RestoreHealth(100);

        //Speed
        increasedSpeed = movementScript.totalMoveSpeed * 0.5f;
        movementScript.moveSpeed += increasedSpeed;

        //Attack Speed
        increasedAttackSpeed = shootingScript.totalFireRate * 0.5f;
        shootingScript.fireRate += increasedAttackSpeed;



    }

    //This restores the values after the special.
    public override void Return(GameObject player)
    {
        //Health
        pHealthScript.maxHealth -= 100;
        pHealthScript.RestoreHealth(50);

        //Speed
        movementScript.moveSpeed -= increasedSpeed;

        //Attack Speed 
        shootingScript.fireRate -= increasedAttackSpeed;



    }
}