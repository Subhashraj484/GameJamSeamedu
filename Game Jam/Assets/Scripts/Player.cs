using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D) , typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed =5f;
    [SerializeField] float jumpForce =5f;
    [Space]

    [Header("GroundCheck")]

    [SerializeField] float groundRayLenght = 1f;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    Rigidbody2D rb;
    Vector2 moveDirection;

    [Space]

    [SerializeField] MoveHoldManager moveHoldManager;
    

    private void Start() {
        moveHoldManager.Jump += Jump;
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.freezeRotation = true;
    }

    private void Jump()
    {
        if(!isGrounded) return;

        rb.AddForce(transform.up* jumpForce, ForceMode2D.Impulse );
    }

    void FixedUpdate()
    {
        

        moveDirection = moveHoldManager.MoveDirectionV2*playerSpeed;
        moveDirection.y = rb.velocity.y;
        rb.velocity = moveDirection;


        if(Physics2D.Raycast(transform.position , Vector3.down , groundRayLenght , groundLayer))
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
        Gizmos.DrawRay(transform.position , Vector3.down);
    }

}
