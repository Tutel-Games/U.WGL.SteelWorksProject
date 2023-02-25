using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlatformerPlayer : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    public AudioSource _as;
    bool isGrounded;

    float moveInput;
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }
    
    public void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                _as.Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpsLeft--;
            }
                               
        }
        
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, .5f, GroundLayer);
        ResetJumps();
    }

    public void ResetJumps()
    {
        if (isGrounded)
        {
            jumpsLeft = jumpsAmount;// jumpsAmount =2;
        }
    }
}
