using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody2D playerRB;

    private bool isGrounded;

    private float offscreenX;
    private float offscreenY;

    [SerializeField]
    Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int maxHealth;
    private int currHealth;
    public int extraJumps;
    private int currExtraJumps;

    public GameObject platformSpawner;
    public GameObject restartDisplay;


    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        offscreenX = -5.0f;
        offscreenY = -3.44f;
        currHealth = maxHealth;
        currExtraJumps = extraJumps;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(currExtraJumps);

        if (currHealth <= 0)
        {
            Die();
        }

        if (isGrounded)
        {
            currExtraJumps = extraJumps;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("up")) && currExtraJumps > 0)
        {

            Jump();
            currExtraJumps--;

        } else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("up")) && currExtraJumps == 0 && isGrounded)
        {
            Jump();
        }

        if (playerRB.position.x <= offscreenX || playerRB.position.y <= offscreenY)
        {
            currHealth = 0;
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

    void TakeDamage(int dmg)
    {
        currHealth -= dmg;
    }

    void Die()
    {
        Debug.Log("dead");
        platformSpawner.SetActive(false);
        restartDisplay.SetActive(true);

        Destroy(this.gameObject);
    }
}
