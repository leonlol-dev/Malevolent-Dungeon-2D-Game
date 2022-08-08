using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    public float destroyTimer = 3f;

    // Projectile deletes it self after a certain amount of time.
    void Start()
    {
        DestroyTimer();
    }


    private void DestroyTimer()
    {
        Destroy(this.gameObject, destroyTimer);
    }

}
