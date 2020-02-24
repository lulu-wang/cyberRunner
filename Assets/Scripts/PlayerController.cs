using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

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
    public int attackDamage;
    public int score;

    public GameObject platformSpawner;
    public GameObject restartDisplay;
    public GameObject effect;

    public Text healthDisplay;
    public Text scoreDisplay;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;



    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        offscreenX = -5.0f;
        offscreenY = -3.44f;
        currHealth = hearts.Length;
        currExtraJumps = extraJumps;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currExtraJumps);
        healthDisplay.text = currHealth.ToString();
        scoreDisplay.text = score.ToString();

        if (currHealth <= 0)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //attack
            Attack();
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

    void SetHealth(int newHealth)
    {
        if (newHealth > hearts.Length)
            newHealth = hearts.Length; //can't exceed maximum num of hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < newHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }


    void Jump()
    {
        Vector2 jumpVector = new Vector2(playerRB.velocity.x, jumpSpeed);
        playerRB.velocity = jumpVector;
        Instantiate(effect, transform.position, Quaternion.identity);

    }

    void TakeDamage(int dmg)
    {
        Debug.Log("took a hit");
        if (currHealth <= 0)
        {
            Die();
        }
        currHealth -= 1;
        SetHealth(currHealth);
    }

    void Attack()
    {
        Vector2 bulletStartPos = new Vector2(transform.position.x + 0.3f, transform.position.y);
        Instantiate(bullet, bulletStartPos, Quaternion.identity);
        
    }

    void IncreaseScore(int amount)
    {
        score+= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Debug.Log("wat");
            IncreaseScore(1);
            Destroy(collision.gameObject);
        }
    }



    void Die()
    {
        Debug.Log("dead");
        platformSpawner.SetActive(false);
        restartDisplay.SetActive(true);

        Destroy(this.gameObject);
    }
}
