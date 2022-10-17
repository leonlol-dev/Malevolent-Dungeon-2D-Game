using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTrigger : MonoBehaviour
{
    private PlayerShooting pShooting;

    private void Start()
    {
        pShooting = transform.parent.GetComponent<PlayerShooting>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item" && collision.gameObject.GetComponent("WeaponItem") as WeaponItem != null)
        {
            pShooting.currentItemHover = collision.gameObject;
        }
    }

    
}
