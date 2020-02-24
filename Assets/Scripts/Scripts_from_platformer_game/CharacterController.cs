using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public GameObject gameController;

    public int health = 100;
    public int humanity = 100;
    public int attackDmg = 20;
    public GameObject enemy;
    public bool hasWeapon = false;
    public float moveSpeed = 8f;
    public float jumpSpeed;
    public float attackCd = 0.6f;
    public Collider2D attackTrigger;

    public Color flashColor = Color.red;
    public float flashDelay = 0.02f;
    public int numFlashes = 1;

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    bool isJumping = false;
    bool facingRight = true;
    float startX;

    bool isOnTop = false;

    bool attacking = false;
    float attackTimer = 0;



    [SerializeField] 
    Transform groundCheck;

    [SerializeField]
    Transform ceilingCheck;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackTrigger.enabled = false;
        startX = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        } 
        if (humanity < 90)
        {

            if (humanity < 50)
            {

                if (humanity < 10)
                {

                }
            } 
        }

        RaycastHit2D groundRayCast = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        RaycastHit2D enemyRayCast = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Enemy"));

        if (groundRayCast || enemyRayCast)
        {
            isGrounded = true;
            isJumping = false;
            if (enemyRayCast)
            {
                isOnTop = true;
                enemy.SendMessageUpwards("Damage", attackDmg);
            }
            else
            {
                isOnTop = false;
            }
        }
        else
        {
            isGrounded = false;
        }

       

        if ((Input.GetKey("up") || Input.GetKey("w")) && isGrounded)
        {
            Jump();

        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("x") && hasWeapon && !attacking)
        {
            Attack();

        } else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (!attacking)
            {
                WalkRight();
            }

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (!attacking)
            {
                WalkLeft();
            }
        }
        else
        {
            Idle();
        }
    }


    public void Idle()
    {
        if (!isJumping && !attacking)
        {
            if (!hasWeapon)
            {
                animator.Play("playerIdle");

            }
            else
            {
                animator.Play("playerIdleWeapon");
            }

        }
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }

    public void Jump()
    {
        //Debug.Log("is grounded");
        isJumping = true;
        if (!hasWeapon)
        {
            animator.Play("playerJump");

        }
        else
        {
            animator.Play("playerJumpWeapon");
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
    }

    public void Attack()
    {
        //Debug.Log("attacking");
        attacking = true;
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        animator.Play("playerAttack");

        attackTimer = attackCd;
        attackTrigger.enabled = true;
    }

    public void WalkLeft()
    {
        rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        if (isGrounded && !isJumping && !attacking)
        {
            if (!hasWeapon)
            {
                animator.Play("playerWalk");
            }
            else
            {
                animator.Play("playerWalkWeapon");
            }
        }
        facingRight = false;
        transform.localScale = new Vector3(-startX, transform.localScale.y, transform.localScale.z);
    }

    public void WalkRight()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        if (isGrounded && !isJumping)
        {
            if (!hasWeapon)
            {
                animator.Play("playerWalk");
            }
            else
            {
                animator.Play("playerWalkWeapon");
            }

        }
        facingRight = true;
        transform.localScale = new Vector3(startX, transform.localScale.y, transform.localScale.z);
    }

    public IEnumerator Damage (int dmg)
    {
        if (!isOnTop)
        {
            Debug.Log("player health:" + health);
            health -= dmg;
            for (int i = 0; i < numFlashes; i++)
            {
                spriteRenderer.color = flashColor;
                yield return new WaitForSeconds(flashDelay);
                spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(flashDelay);
            }
            //animator.Play("playerDamage");
        }

    }

    public void EquipWeapon()
    {
        hasWeapon = true;
    }

    public void Die()
    {
        rb2d.velocity = new Vector2(0, 0);
        gameController.SendMessageUpwards("gameOver");
        //animator.Play("playerDie");
    }
}
