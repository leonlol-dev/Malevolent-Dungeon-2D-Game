using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggersProjectile : MonoBehaviour
{
    public GameObject extraProjectile;
    public Transform leftOrigin;
    public Transform rightOrigin;
    public GameObject player;
    private PlayerShooting shootScript;

    public float timer = 0.45f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();

        DestroyTimer(timer);

        //Quaternion.Euler(0, 0, 45f)
        GameObject daggerOne = Instantiate(extraProjectile, leftOrigin.position, leftOrigin.rotation);
        daggerOne.GetComponent<ExtraDagger>().timer = timer;
        daggerOne.transform.localScale = new Vector3(shootScript.totalProjectileSize, shootScript.totalProjectileSize, 0);
        Rigidbody2D rbOne = daggerOne.GetComponent<Rigidbody2D>();
        rbOne.AddForce(leftOrigin.up * shootScript.totalBulletForce, ForceMode2D.Impulse);

        GameObject daggerTwo = Instantiate(extraProjectile, rightOrigin.position, rightOrigin.rotation);
        daggerTwo.GetComponent<ExtraDagger>().timer = timer;
        daggerTwo.transform.localScale = new Vector3(shootScript.totalProjectileSize, shootScript.totalProjectileSize, 0);
        Rigidbody2D rbTwo = daggerTwo.GetComponent<Rigidbody2D>();
        rbTwo.AddForce(rightOrigin.up * shootScript.totalBulletForce, ForceMode2D.Impulse);
        
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyTimer(timer));

        player = GameObject.FindWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();

        //Quaternion.Euler(0, 0, 45f)
        GameObject daggerOne = Instantiate(extraProjectile, leftOrigin.position, leftOrigin.rotation);
        daggerOne.GetComponent<ExtraDagger>().timer = timer;
        daggerOne.transform.localScale = new Vector3(shootScript.totalProjectileSize, shootScript.totalProjectileSize, 0);
        Rigidbody2D rbOne = daggerOne.GetComponent<Rigidbody2D>();
        rbOne.AddForce(leftOrigin.up * shootScript.totalBulletForce, ForceMode2D.Impulse);

        GameObject daggerTwo = Instantiate(extraProjectile, rightOrigin.position, rightOrigin.rotation);
        daggerTwo.GetComponent<ExtraDagger>().timer = timer;
        daggerTwo.transform.localScale = new Vector3(shootScript.totalProjectileSize, shootScript.totalProjectileSize, 0);
        Rigidbody2D rbTwo = daggerTwo.GetComponent<Rigidbody2D>();
        rbTwo.AddForce(rightOrigin.up * shootScript.totalBulletForce, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            Pool.Instance.Deactivate(this.gameObject);
        }


    }

    IEnumerator DestroyTimer(float _destroyTimer)
    {
        yield return new WaitForSeconds(_destroyTimer);
        Pool.Instance.Deactivate(this.gameObject);
        Debug.Log("missile deactiaved!");
    }

}
