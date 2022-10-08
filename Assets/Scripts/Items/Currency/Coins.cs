using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public bool randomAmount;
    public int coinAmount = 1;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;

    private bool hasTarget;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(randomAmount)
        {
            coinAmount = Random.Range(1, 20);
        }
    }

    private void FixedUpdate()
    {
        if(hasTarget)
        {
            Vector2 targetDirection = (targetPos - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerCurrency moneyScript = collision.GetComponent<PlayerCurrency>();
            moneyScript.ReceiveGold(coinAmount);
            Destroy(this.gameObject);
        }
    }

    public void SetTarget(Vector3 _target)
    {
        targetPos = _target;
        hasTarget = true;
    }
}
