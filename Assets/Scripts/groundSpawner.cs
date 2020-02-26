using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    public float startWaitTime;
    public float waitTimeMin;
    public float waitTimeMax;
    private float currWaitTime;

    public GameObject ground;

    private void Start()
    {
        transform.position = new Vector2(transform.position.x, -2.3f);
        currWaitTime = startWaitTime;
    }

    private void Update()
    {
        if (currWaitTime <= 0)
        {
            float randWaitTime = Random.Range(waitTimeMin, waitTimeMax);
            Instantiate(ground, transform.position, Quaternion.identity);

            currWaitTime = randWaitTime;
        }
        else
        {
            currWaitTime -= Time.deltaTime;
        }
    }
}
