using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health = 50;
    bool attacking = false;
    public int atkDmg = 10;
    public float moveSpeed;
    public GameObject player;
    //public Collider2D attackTrigger;
    public float flashDelay = 0.02f;
    public Color flashColor = Color.red;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2d;
    float distanceToPlayer;
    float startX;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        startX = transform.localScale.x;
        //attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        //distanceToPlayer = transform.position.x - player.transform.position.x;
        //if (distanceToPlayer > 3.0f)
        //{
        //    //Debug.Log("onRight");
        //    //move left
        //    //attackTrigger.enabled = false;
        //    rb2d.velocity = new Vector2(-moveSpeed, 0);
        //    transform.localScale = new Vector3(startX, transform.localScale.y, transform.localScale.z);
        //}
        //else if (distanceToPlayer < -3.0f)
        //{
        //    //move right
        //    //attackTrigger.enabled = false;
        //    rb2d.velocity = new Vector2(moveSpeed, 0);
        //    transform.localScale = new Vector3(-startX, transform.localScale.y, transform.localScale.z);

        //}
        //else
        //{
        //    //attackTrigger.enabled = true;

        //    if (Mathf.Abs(distanceToPlayer) < 1.0f)
        //    {
        //        rb2d.velocity = new Vector2(rb2d.velocity.x * 0.5f, 0);
        //    }
        //    else
        //    {
        //        rb2d.velocity = new Vector2(rb2d.velocity.x * 1.1f, 0);
        //    }

        //}
    }

    public IEnumerator Damage(int dmg)
    {

        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDelay);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(flashDelay);

        Debug.Log("enemy health:" + health);
        health -= dmg;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        player.SendMessageUpwards("Damage", atkDmg);
    }

    public void Die()
    {
        //animator.Play("enemyDeath");
        Destroy(gameObject);
    }
}
