using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public float rotationSpeedMultiplier = 1f;
    public float destroyTimer = 0.5f;

    private float rotationSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        projectile = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        destroyTimer = player.GetComponent<PlayerShooting>().totalRange;


    }

    private void OnEnable()
    {
        //Get Destroy timer
        destroyTimer = player.GetComponent<PlayerShooting>().totalRange;

        //Start destroy timer
        StartCoroutine(DestroyTimer(destroyTimer));
    }

    void Update()
    {
        //Spinning rotation
        rotationSpeed = rotationSpeedMultiplier * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, -rotationSpeed);
    }

    IEnumerator DestroyTimer(float _destroyTimer)
    {
        yield return new WaitForSeconds(_destroyTimer);
        Pool.Instance.Deactivate(this.gameObject);
        Debug.Log("missile deactiaved!");
    }

}
