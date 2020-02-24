using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody2D playerRB;

    private bool isGrounded;


    [SerializeField]
    Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D groundRayCast = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //if (groundRayCast)
        //{
        //    Debug.Log("isGrounded");
        //    isGrounded = true;
        //} else
        //{
        //    isGrounded = false;
        //}

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey("up")) && isGrounded)
        {
            Jump();

        }


    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }


    void Jump()
    {
        Vector2 jumpVector = new Vector2(playerRB.velocity.x, jumpSpeed);
        playerRB.velocity = jumpVector;
    }
}
