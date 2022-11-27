using UnityEngine;

public class EnemyRadialAttack : MonoBehaviour
{
    public bool canFire;

    [Header("Projectile Prefab")]
    public GameObject projectile;

    [Header("Projectile Variables")]
    public int damage = 1;
    public float fireRate = 1f;
    public float projectileLifetime = 0.55f;
    public float radius = 5f;
    public float moveSpeed = 5f;
    public int numberOfProjectiles = 1;

    //Private
    private float nextTimeToFire = 0f;
    private Vector2 startPoint;


    // Start is called before the first frame update
    void Start()
    {
        //canFire = false;
        projectile.GetComponent<EnemyProjectile>().damage = damage;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeToFire && canFire == true)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            SpawnProjectiles(numberOfProjectiles);
        }
    }


    public void SpawnProjectiles(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < _numberOfProjectiles; i++)
        {
            float projectileDirXposition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposiiton = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposiiton);
            Vector2 projectileMoveDirection = (projectileVector - new Vector2(transform.position.x, transform.position.y)).normalized * moveSpeed;

            //holy shit i figured this out on my own, fuck quaternions.
            float rotation = Mathf.Atan2(projectileDirXposition, projectileDirYposiiton) * Mathf.Rad2Deg;
            var proj = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -rotation));

            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            proj.GetComponent<EnemyProjectile>().lifeTime = projectileLifetime;


            angle += angleStep;
        }
    }
}
