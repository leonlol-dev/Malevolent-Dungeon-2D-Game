using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Special/Loaded"))]
public class LoadedSpecial : SpecialAttack
{
    public string title = "Loaded Special";
    public string description = "Player has double attack speed but halved movement speed";
    public float cooldown = 6f;
    public float duration = 2.5f;
    public GameObject prefab;

    PlayerHealth pHealthScript;
    PlayerShooting shootingScript;
    PlayerMovement movementScript;

    private float decreasedWalkSpeed;
    private float increasedAttackSpeed;

    public override float getCooldown { get { return cooldown; } }
    public override float getDuration { get { return duration; } }

    public override GameObject getPrefab { get { return prefab; } }

    //This is what the special does.
    public override void Special(GameObject player)
    {
        //Get components at the start of the special then save it into a variable.
        shootingScript = player.GetComponent<PlayerShooting>();
        movementScript = player.GetComponent<PlayerMovement>();

        //Attack Speed
        increasedAttackSpeed = shootingScript.totalFireRate;
        shootingScript.fireRate += increasedAttackSpeed;

        //Slower Speed
        decreasedWalkSpeed = movementScript.totalMoveSpeed * 0.5f;
        movementScript.moveSpeed -= decreasedWalkSpeed;


    }

    //This restores the values after the special.
    public override void Return(GameObject player)
    {
        //Attack Speed
        shootingScript.fireRate -= increasedAttackSpeed;

        //Restore speed
        movementScript.moveSpeed += decreasedWalkSpeed;


    }

    public override void Equip(GameObject player)
    {
        //i dont like the look of this so im not using it
        player.GetComponent<PlayerSpecialAttack>().currentSpecial = this;
        player.GetComponent<PlayerSpecialAttack>().currentSpecialPrefab = getPrefab;
        player.GetComponent<PlayerSpecialAttack>().cooldown = getCooldown;
        player.GetComponent<PlayerSpecialAttack>().duration = getDuration;
    }
}
