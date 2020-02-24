using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    public float bulletSpeed;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(transform.position.x + bulletSpeed * Time.deltaTime, transform.position.y);
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //player.SendMessage("IncreaseScore", collision.gameObject.GetComponent<EnemyBehavior>().worth);
            Destroy(collision.gameObject);
        }
    }
}
