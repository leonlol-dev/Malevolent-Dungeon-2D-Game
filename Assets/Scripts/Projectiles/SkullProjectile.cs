using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullProjectile : MonoBehaviour
{
    //This is basically a copy of the homing projectile script but with a different
    //collider effect.
    private Transform target;
    private Rigidbody2D rb;
    private PlayerShooting shootScript;

    public float speed = 10f;
    public float rotateSpeed = 5000f;
    public float destroyTimer = 1f;
    public float radius = 1f;
    public GameObject player;
    public GameObject explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {

        //Grab components.
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();
        rb = GetComponent<Rigidbody2D>();

        //Set the speed of the homing missiles to the bullet force.
        speed = shootScript.totalBulletForce;

    }

    private void OnEnable()
    {
        //Start Coroutine for the destroy timer.
        StartCoroutine(DestroyTimer(destroyTimer));

        //Grab components.
        if(target=null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        else
        {
            return;
        }
        
        player = GameObject.FindGameObjectWithTag("Player");
        shootScript = player.GetComponent<PlayerShooting>();
        rb = GetComponent<Rigidbody2D>();

        //Set the speed of the homing missiles to the bullet force.
        speed = shootScript.totalBulletForce;
    }

    private void FixedUpdate()
    {
        //Find the target, if there is no target - stop this calculation.
        target = FindClosestEnemy().transform;
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
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            Explode();
        }


    }

    private void Explode()
    {
        //Instantiate explosion
        GameObject particleSystem = Instantiate(explosionPrefab, transform.position, transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D nearByObject in colliders)
        {
            EnemyHealth enemy = nearByObject.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                enemy.TakeDamage((int)player.GetComponent<PlayerShooting>().totalDamage / 2);
            }
        }

        Destroy(particleSystem, 1f);
        Pool.Instance.Deactivate(this.gameObject);


    }

    IEnumerator DestroyTimer(float _destroyTimer)
    {
        yield return new WaitForSeconds(_destroyTimer);
        Pool.Instance.Deactivate(this.gameObject);
        Debug.Log("missile deactiaved!");
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
        foreach(GameObject go in gameObjects)
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

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
