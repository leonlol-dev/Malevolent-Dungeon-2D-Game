using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingProjectile : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    public float speed = 10f;
    public float rotateSpeed = 50f;
    public float destroyTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Grab components.
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody2D>();
        DestroyTimer();
    }


    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

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
            Destroy(this);
        }

        Destroy(this);
    }

    private void DestroyTimer()
    {
        Destroy(this, destroyTimer);
    }
}
