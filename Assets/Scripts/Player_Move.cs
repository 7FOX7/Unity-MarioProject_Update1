using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    // some important variables for controlling player characteristics
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower;
    private int jumpCount = 0;
    private int maxJumps = 2;
    private float moveX;
    public bool isGrounded = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        // CONTROLS:
        // 1. get the input of 'X' gizmo; 
        moveX = Input.GetAxis("Horizontal");

        // 2. checks if the user presses the button (by default space bar) 
        // if true - call 'Jump' method; 
        if (Input.GetButtonDown("Jump") && (isGrounded == true /* == true */ || jumpCount < maxJumps))
        {
            Jump();
        }
        // ANIMATION; 
        // PLAYER_DIRECTION:
        // 1. if the player moves in the left direction - flip Player; 
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        // 2. if player moves in the right direction - flip Player; 
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        // PHYSICS: 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.one * playerJumpPower);
        //isGrounded = false;
        jumpCount++; 
    }

    void FlipPlayer()
    {
        // FLIPPING PLAYER: 
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log($"{gameObject} has collided with {col.collider.name}"); 
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            
            // if the Player is on the ground, the jumpCount is set to 0 by default; 
            jumpCount = 0; 
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGrounded = false; 
        }
    }
}