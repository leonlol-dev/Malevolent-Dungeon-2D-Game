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
    public float baseMoveSpeed = 5f;

    [Header("Modifiers")]
    public float moveSpeed = 0f;

    [HideInInspector]
    public float totalMoveSpeed;

    //Private
    private Vector2 movement;
    //Mouse
    private Vector2 mousePos;

    private void Start()
    {
        CalculateTotal();
    }

    private void FixedUpdate()
    {
        CalculateTotal();

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

        //Move rigidbody
        rb.MovePosition(rb.position + movement * totalMoveSpeed * Time.fixedDeltaTime);


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

    public void CalculateTotal()
    {
        totalMoveSpeed = baseMoveSpeed + moveSpeed;
    }
}
