using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggersProjectile : MonoBehaviour
{
    public GameObject extraProjectile;
    public Transform leftOrigin;
    public Transform rightOrigin;
    public GameObject player;

    public float timer = 0.45f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        DestroyTimer(timer);

        //Quaternion.Euler(0, 0, 45f)
        GameObject daggerOne = Instantiate(extraProjectile, leftOrigin.position, leftOrigin.rotation);
        daggerOne.GetComponent<ExtraDagger>().timer = timer;
        Rigidbody2D rbOne = daggerOne.GetComponent<Rigidbody2D>();
        rbOne.AddForce(leftOrigin.up * player.GetComponent<PlayerShooting>().bulletForce, ForceMode2D.Impulse);

        GameObject daggerTwo = Instantiate(extraProjectile, rightOrigin.position, rightOrigin.rotation);
        daggerTwo.GetComponent<ExtraDagger>().timer = timer;
        Rigidbody2D rbTwo = daggerTwo.GetComponent<Rigidbody2D>();
        rbTwo.AddForce(rightOrigin.up * player.GetComponent<PlayerShooting>().bulletForce,ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            Destroy(this.gameObject);
        }


    }

    private void DestroyTimer(float _timer)
    {
        Destroy(this.gameObject, _timer);

    }

}
