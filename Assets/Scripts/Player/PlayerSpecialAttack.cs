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
    public GameObject currentItemHover;

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


        //===================================================================================
        //Any further updates to this script make sure to do it above these if statements.
        //This checks if the player is hovering over an item and will return back to the top
        //if there isn't.
        //===================================================================================

        if (currentItemHover == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) && currentItemHover.GetComponent<SpecialItem>().playerInProximity && canSpecial)
        {
            player.GetComponent<PlayerAudioHandler>().pickUpSound(true);
            PickUpSpecial(currentItemHover.GetComponent<SpecialItem>().specialAttack);
            Destroy(currentItemHover);
        }

        else if (Input.GetKeyDown(KeyCode.E) && !canSpecial && currentItemHover.GetComponent<SpecialItem>().playerInProximity)
        {
            //Play Reject clip
            player.GetComponent<PlayerAudioHandler>().pickUpSound(false);
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
            
            //Drop current special in game world (the player.transform.GetChild should be the origin.)
            Instantiate(currentSpecialPrefab, player.transform.GetChild(0).transform.position, Quaternion.identity);
        }

        currentSpecial = _special;
        currentSpecialPrefab = _special.getPrefab;
        cooldown = _special.getCooldown;
        duration = _special.getDuration;

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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item" && collision.gameObject.GetComponent("SpecialItem") as SpecialItem != null)
        {
            currentItemHover = collision.gameObject;
        }
    }


}
