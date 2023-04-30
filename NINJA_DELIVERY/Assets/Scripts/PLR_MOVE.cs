using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLR_MOVE : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    [SerializeField] private GameObject Player;
    [SerializeField]  Collider2D myCollider;
    public bool isGround;
    public LayerMask WhatIsGround;

    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        isGround = Physics2D.IsTouchingLayers(myCollider, WhatIsGround);

        Player.transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGround)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
            }
        }
    }
}

//new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
