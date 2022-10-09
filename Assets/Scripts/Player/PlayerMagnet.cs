using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if(collision.gameObject.TryGetComponent<Coins>(out Coins coin))
        //{
        //    coin.SetTarget(transform.parent.position);
        //}

        //Get the trigger's parent to change the script. As the coin's trigger is a child.
        if (collision.transform.parent.gameObject.TryGetComponent<Coins>(out Coins coin))
        {
            coin.SetTarget(transform.parent.position);
        }
    }


}
