using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    public float destroyTimer = 3f;

    // Projectile deletes it self after a certain amount of time.
    void Start()
    {
        StartCoroutine(DestroyTimer(destroyTimer));
    }


    IEnumerator DestroyTimer(float _destroyTimer)
    {
        yield return new WaitForSeconds(_destroyTimer);
        Pool.Instance.Deactivate(this.gameObject);
        Debug.Log("missile deactiaved!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy projectile if it hits an enemy.
        if (collision.gameObject.tag == "Enemy")
        {
            Pool.Instance.Deactivate(this.gameObject);
        }


    }
}
