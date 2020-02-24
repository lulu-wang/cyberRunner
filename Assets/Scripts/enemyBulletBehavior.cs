using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletBehavior : MonoBehaviour
{

    public float bulletSpeed;
    public int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 newPos = new Vector2(transform.position.x - bulletSpeed * Time.deltaTime,
            transform.position.y + 0.5f * bulletSpeed * Time.deltaTime);
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessageUpwards("TakeDamage", bulletDamage);
            Destroy(this.gameObject);
        }
    }
}
