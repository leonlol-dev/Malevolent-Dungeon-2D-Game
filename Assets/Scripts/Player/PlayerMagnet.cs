using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Coins>(out Coins coin))
        {
            coin.SetTarget(transform.parent.position);
        }
    }
}
