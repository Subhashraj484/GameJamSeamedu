using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D) , typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed =5f;
    [SerializeField] float jumpForce =5f;
    [Space]

    [Header("GroundCheck")]

    [SerializeField] float groundRayLenght = 1f;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    [Space]

    [Header("Gravity Inverse")]
    [SerializeField] bool inverseGravity;
    int gravityMultiplayer = 1;
    Vector3 rotation;
    InputManager inputManager;
    Rigidbody2D rb;
    Vector2 moveDirection;
    private void Start() {
        inputManager = InputManager.Instance;
        inputManager.Jump += Jump;
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.freezeRotation = true;

        if(inverseGravity) 
        {
            gravityMultiplayer = -1;
            rb.gravityScale = gravityMultiplayer;
            rotation  = new Vector3(0,0,360);
            transform.rotation = Quaternion.Euler(rotation );
        }
        else 
        {
            gravityMultiplayer = 1;
            rb.gravityScale = gravityMultiplayer;
            rotation  = new Vector3(0,0,0);
            transform.rotation = Quaternion.Euler(rotation );


    
        }
        
        
    }


    private void Jump()
    {
        if(!isGrounded) return;

        rb.AddForce(gravityMultiplayer*transform.up* jumpForce, ForceMode2D.Impulse );
    }

    void FixedUpdate()
    {
        

        moveDirection = inputManager.MoveDirectionV2*playerSpeed;
        moveDirection.y = rb.velocity.y;
        rb.velocity = moveDirection;


        if(Physics2D.Raycast(transform.position , -gravityMultiplayer*transform.up , groundRayLenght , groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position , -gravityMultiplayer*transform.up);
    }

}
