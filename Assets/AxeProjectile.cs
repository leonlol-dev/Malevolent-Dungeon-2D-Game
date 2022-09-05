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
    void Start()
    {
        projectile = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");

        //Start destroy timer
        DestroyTimer(destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        rotationSpeed = rotationSpeedMultiplier * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, -rotationSpeed);
    }

    private void DestroyTimer(float timer)
    {
        Destroy(gameObject, timer);
    }
}
