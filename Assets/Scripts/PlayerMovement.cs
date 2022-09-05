using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Things to set")]
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Camera cam;
    public GameObject origin;

    [Header("Modifiers")]
    public float moveSpeed = 5f;

    //Private
    private Vector2 movement;
    //Mouse
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;
        origin.transform.up = dir;

    }

    private void FixedUpdate()
    {
        //Move rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }


    }

    public void SetMovementSpeed(float newMovementSpeed)
    {
        moveSpeed = newMovementSpeed;
    }
}
