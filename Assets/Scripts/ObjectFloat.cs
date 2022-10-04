using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    public float degreesPerSecond = 15f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float itemRadius = 1f;
    public float rangeMovement = 0.1f;
    public float timer = 0.55f;
    Vector3 force;
    public float magnitude = 1000f;

    //Store position variables
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();

    private bool itemStaying = false;
    private bool floating = true;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(floating)
        {
            // Make object float up and down.
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
  

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {

            //floating = false;
            //Debug.Log("item is stuck in an item");
            //transform.position = (transform.position - collision.transform.position).normalized * rangeMovement + collision.transform.position;
            ////transform.position = Vector3.MoveTowards(transform.position, (transform.position - collision.transform.position).normalized * rangeMovement, 0.33f * Time.deltaTime);
            //posOffset = transform.position;


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If collision is an item, to prevent stacking - need to move object away.
        if (collision.gameObject.tag == "Item")
        {
            //I don't want the items to continuously keep pushing each other.
            //StartCoroutine(WaitThenPush(timer, collision));
            floating = false;
            //transform.position = Vector3.MoveTowards(transform.position, (transform.position - collision.transform.position).normalized * rangeMovement, 0.33f * Time.deltaTime);
            //posOffset = transform.position;

            // Rotate gameobject to face "away" from the player who entered the collider
            Vector3 targetDirection = transform.position - collision.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Mathf.PI, 10);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            //transform.rotation = Quaternion.LookRotation(newDirection); 
            // (This section works as expected) script to move gameobject away from player.
            transform.position = Vector3.MoveTowards(transform.position, collision.transform.position, -1 * rangeMovement * Time.deltaTime);
            posOffset = transform.position;


        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //posOffset = transform.position;
            floating = true;
        }
    }

    private void PushItem(Collider2D collision)
    {
        floating = false;
        force = transform.position - collision.transform.position;
        force.Normalize();
        GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
    }

    private IEnumerator WaitThenPush(float timer, Collider2D collision)
    {
        yield return new WaitForSeconds(timer);
        PushItem(collision);
    }
    
}
