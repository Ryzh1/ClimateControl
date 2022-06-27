using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    Rigidbody2D rb;
    public float Movespeed = 2f;
    
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;


    private float maxHealth = 100;
    public float CurrentHealth;
    private BoxCollider2D boxCollider;

    private Animator animation;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHealth = maxHealth;
        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();


        animation = GetComponent<Animator>();
        animation.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(0f, 0.02f);
        }

        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(0f, 0.02f);
        }


        //Anim
        if (movement.x != 0 || movement.y != 0)
            animation.SetFloat("Speed", 1);
        else
            animation.SetFloat("Speed", 0);



    }


    private void FixedUpdate()
    {
       
        
        rb.MovePosition(rb.position + movement * Movespeed * Time.fixedDeltaTime);
        
    }

    
}
