using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer sprite;

    float horizontal;
    float vertical;
    float moveLimiter = Mathf.Sqrt(2)/2;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    
    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if(horizontal > 0)
            sprite.flipX = true;
        else if (horizontal < 0)
            sprite.flipX = false;

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
