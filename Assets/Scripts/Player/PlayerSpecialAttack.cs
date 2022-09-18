using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public SpecialAttack currentSpecial;
    public GameObject currentSpecialPrefab;

    public float cooldown;
    public float duration;
    public bool canSpecial;


    //Private
    private GameObject player;

    private void Start()
    {
        canSpecial = true;
        currentSpecial = null;

        player = this.gameObject;

        
   
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpecial && currentSpecial != null)
        {
            canSpecial = false;
            StartCoroutine(SpecialDuration(duration));
            StartCoroutine(SpecialCooldown(cooldown));
            

        }
    }

    public void PickUpSpecial(SpecialAttack _special)
    {
        //If there is no current special - disregard.
        if (currentSpecial != null)
        {
            if(!canSpecial)
            {
               //Reset the current special, if the player were to pick it up.
               currentSpecial.Return(player);
            }
            
            //Drop current special in game world
            Instantiate(currentSpecialPrefab, player.transform.position, Quaternion.identity);
        }

        

        //canSpecial = true;

        //Now change the special.
        currentSpecial = _special;
        currentSpecialPrefab = _special.getPrefab;
        cooldown = _special.getCooldown;
        duration = _special.getDuration;

    }

    public void DropSpecial()
    {
        //Instantiate

        
            
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
        currentSpecial.Special(player);
        yield return new WaitForSeconds(_duration);
        currentSpecial.Return(player);
        Debug.Log("Special Ended!");


    }

 
    
}
