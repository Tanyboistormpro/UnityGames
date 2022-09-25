using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float velocityY = -2f;

    private float horizontalMove;
    private float Speed;
    private bool isFacingRight = true;
    private bool moveLeft, moveRight; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float jumpHeight = 14f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = 8f;
        moveRight = false;
        moveLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * Speed;

        if (moveLeft)
        {
            rb.velocity = new Vector2(-Speed, velocityY);
            Flip();
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(Speed, velocityY);
            Flip();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip()
    {
        if (isFacingRight && horizontalMove < 0f || !isFacingRight && horizontalMove > 0)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void StopMoving()
    {
        moveRight = false;
        moveLeft = false;
        rb.velocity = Vector2.zero;
    }
}
