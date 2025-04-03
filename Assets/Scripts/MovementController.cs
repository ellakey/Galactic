using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 5;
    Rigidbody2D playerrigidbody2D;
    SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator = null;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private int maxJumpCount = 1;
    private int jumpCount = 0;
    [SerializeField] private Transform bottomCollisionPoint = null;
    public bool isGround = true;
    [SerializeField] private LayerMask Tiles;

    private void Awake()
    {
        playerrigidbody2D = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            jumpCount ++;
            isGround = false;
            playerrigidbody2D.velocity = new Vector2(playerrigidbody2D.velocity.x, jumpForce);
        }

        if(isGround == true && jumpCount > 0)
        {
            jumpCount = 0;
        }
        playerrigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * maxVelocity, playerrigidbody2D.velocity.y);
    }

    private void LateUpdate()
    {
        if(playerrigidbody2D.velocity.x < 0f)
        playerSpriteRenderer.flipX = true;
        else if(playerrigidbody2D.velocity.x > 0f)
        playerSpriteRenderer.flipX = false;


        if(playerAnimator != null)
        {
            playerAnimator.SetFloat("xVelocity", Math.Abs(playerrigidbody2D.velocity.x));
            playerAnimator.SetFloat("yVelocity",playerrigidbody2D.velocity.y);
            playerAnimator.SetBool("isGround", isGround);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = Physics2D.OverlapCircle(bottomCollisionPoint.position, .5f, Tiles);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       isGround = false;  
    }
}
