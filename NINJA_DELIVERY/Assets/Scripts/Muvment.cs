using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muvment : MonoBehaviour
    {
        [SerializeField] public float speed = 5f; 
        [SerializeField] public float jumpForce = 5f; 
        [SerializeField] public Transform triggerR;
        [SerializeField] public Transform triggerL;
        [SerializeField] private bool isMovingRight = true;
        
        [SerializeField] private Transform groundCheckTransform;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private float groundCheckRadius = 0.2f;
        
        private Rigidbody2D rb;
        [SerializeField] public bool isGrounded;

        private Animator anim;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            MoveX();
            
        }

        void Update()
        {
            ChangeVector();
            GrounCheck();
            Jump();
            Tackles();
        }
        
        
        

        private void MoveX()
        {
            if (isMovingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }

        private void ChangeVector()
        {
            if(transform.position.x > triggerR.position.x && isMovingRight && Input.GetKey(KeyCode.A))
            {
                isMovingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(transform.position.x < triggerL.position.x && !isMovingRight && Input.GetKey(KeyCode.D))
            {
                isMovingRight = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void GrounCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayerMask);
            anim.SetBool("onGround", isGrounded);
            
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }

        private void Tackles()
        {
            if (Input.GetKey(KeyCode.LeftControl) && isGrounded)
            {
                anim.SetBool("tackles", true);
            }
            else
            {
                anim.SetBool("tackles", false);
            }
        }
    }
