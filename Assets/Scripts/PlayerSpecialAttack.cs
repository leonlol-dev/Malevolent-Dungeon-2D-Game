using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public SpecialAttack specialAtk;
    public float cooldown;
    public float duration;
    public bool canSpecial;

    //Private
    private GameObject player;

    private void Start()
    {
        canSpecial = true;
        cooldown = specialAtk.getCooldown;
        duration = specialAtk.getDuration;
        player = this.gameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpecial)
        {
            canSpecial = false;
            StartCoroutine(SpecialDuration(duration));
            StartCoroutine(SpecialCooldown(cooldown));
            

        }
    }

    private void PickUpSpecial()
    {
        //Function so that the player can pick up what special they want on the floor.
        //Change cooldown here too.
    }

    IEnumerator SpecialCooldown(float _cooldown)
    {
        yield return new WaitForSeconds(_cooldown);
        Debug.Log("Can use special again");
        canSpecial = true;
    }

    IEnumerator SpecialDuration(float _duration)
    {
        Debug.Log("Special Started!");
        specialAtk.Special(player);
        yield return new WaitForSeconds(_duration);
        specialAtk.Return(player);
        Debug.Log("Special Ended!");


    }
}
