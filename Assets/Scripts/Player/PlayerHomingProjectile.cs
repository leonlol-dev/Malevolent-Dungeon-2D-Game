using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingProjectile : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    private PlayerShooting shootScript;
    private TrailRenderer trailRenderer;

    public float speed = 10f;
    public float rotateSpeed = 50f;
    public float destroyTimer = 1f;
    public GameObject player;
    public GameObject impactPrefab;
    public GameObject trailPrefab;
    public Transform origin;

    private GameObject trail;

    void Awake()
    { 
        
        //Grab components.
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();
        trailRenderer = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();

        //Set the speed of the homing missiles to the bullet force.
        speed = shootScript.totalBulletForce;
        destroyTimer = shootScript.totalRange;

        

    }

    private void OnEnable()
    {
        //Due to some visual bugs, have to instantiate a trail rather than add it to the projectile object.
        trail = Instantiate<GameObject>(trailPrefab, transform.position, transform.rotation);
        trail.transform.parent = this.transform;

        //Set the speed of the homing missiles to the bullet force.
        speed = shootScript.totalBulletForce;
        destroyTimer = shootScript.totalRange;

        //Start Coroutine for the destroy timer.
        StartCoroutine(DestroyTimer(destroyTimer));

    }

    private void OnDisable()
    {
        //Destroy trail
        Destroy(trail);
    }



    private void FixedUpdate()
    {
        //Find the target, if there is no target - stop this calculation.
        target = FindClosestEnemy().transform;
        if (target == null)
        {
            //STOP THE NULL REFERENCES PLEASE
            target = null;
            return;

        }
        
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
            GameObject impact = Instantiate(impactPrefab, origin.position, origin.rotation);
            Destroy(impact, 0.33f);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            GameObject impact = Instantiate(impactPrefab, origin.position, origin.rotation);
            Destroy(impact, 0.33f);
        }

    }

    //private void DestroyTimer()
    //{
    //    Destroy(this.gameObject, destroyTimer);
    //}

    IEnumerator DestroyTimer(float _destroyTimer)
    {
        yield return new WaitForSeconds(_destroyTimer);
        Pool.Instance.Deactivate(this.gameObject);
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.GetComponent<PlayerMovement>().mousePos;
        foreach (GameObject go in gameObjects)
        {
            Vector3 diff = go.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = go;
                distance = currentDistance;
            }
        }

        return closest;
    }
}
