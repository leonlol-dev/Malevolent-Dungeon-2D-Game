using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifeTime;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        //Rotate towards velocity (this assumes that the sprite is facing right).
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }



}
