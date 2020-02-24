using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public GameObject bullet;

    public int worth;


    //enemy attack intervals
    private float currWaitTime;
    public float startWaitTime;
    public float waitTimeMin;
    public float waitTimeMax;
    public GameObject deatheffect;

    // Start is called before the first frame update
    void Start()
    {
        currWaitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currWaitTime <= 0)
        {
            float randWaitTime = Random.Range(waitTimeMin, waitTimeMax);
            Attack();
            currWaitTime = randWaitTime;
        }
        else
        {
            currWaitTime -= Time.deltaTime;
        }


    }

    void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessageUpwards("TakeDamage", 1);
            Instantiate(deatheffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
