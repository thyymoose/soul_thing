using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private float horizontal;
    private float maxplayerSpeed = 10f;
    private float acellrate = 5;
    private float movment;
    private float speeddif;
    private float speeddirection;
    public Rigidbody2D rb;
    public float jump;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
       // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("w") && IsGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x,jump)); 
        }
        
    }
    void FixedUpdate()
    {
         speeddirection = maxplayerSpeed * horizontal;
        speeddif = speeddirection - rb.velocity.x;
        movment = speeddif * acellrate;

        rb.AddForce(new Vector2(movment, 0));
    }
        private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

    