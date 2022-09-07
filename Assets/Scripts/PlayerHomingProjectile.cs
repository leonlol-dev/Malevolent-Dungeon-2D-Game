using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingProjectile : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    private bool targetFound;
    private PlayerShooting shootScript;

    public float speed = 10f;
    public float rotateSpeed = 50f;
    public float destroyTimer = 1f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Start the destroy timer.
        DestroyTimer();

        //Grab components.
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();
        rb = GetComponent<Rigidbody2D>();

        //Set the speed of the homing missiles to the bullet force.
        speed = shootScript.totalBulletForce;
        
    }


    private void FixedUpdate()
    {
        //Find the target, if there is no target - stop this calculation.
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (target == null) return;
        
        //Find the direction of the target.
        Vector2 direction = (Vector2)target.position - rb.position;

        //Normalise the vector.
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        Vector3.Cross(direction, transform.up);

        rb.velocity = transform.up * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            Destroy(this.gameObject);
        }

        
    }

    private void DestroyTimer()
    {
        Destroy(this.gameObject, destroyTimer);
    }
}
