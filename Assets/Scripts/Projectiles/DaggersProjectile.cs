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
    private float rotationSpeed;

    public float timer = 0.45f;
    public float rotationSpeedMultiplier = 3000f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();
        timer = player.GetComponent<PlayerShooting>().totalRange;
        DestroyTimer(timer);
        
    }

    private void OnEnable()
    {
        //Get Timer
        timer = player.GetComponent<PlayerShooting>().totalRange;

        StartCoroutine(DestroyTimer(timer));

    }

    private void Update()
    {
        //Spinning rotation
        rotationSpeed = rotationSpeedMultiplier * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, -rotationSpeed);
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
