using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private float currWaitTime;
    public float startWaitTime;
    //public float timeDecrease;
    //public float minTimeBtwnSpawns;


    public float waitTimeMin;
    public float waitTimeMax;

    public float lowestSpawnY;
    public float highestSpawnY;

    public GameObject[] platforms;

    private void Start()
    {
        currWaitTime = startWaitTime;
    }

    private void Update()
    {
        if (currWaitTime <= 0)
        {
            float randYPos = Random.Range(lowestSpawnY, highestSpawnY);
            Vector2 randPos = new Vector2(transform.position.x, randYPos);

            float randWaitTime = Random.Range(waitTimeMin, waitTimeMax);

            int randIndex = Random.Range(0, platforms.Length);

            Instantiate(platforms[randIndex], randPos, Quaternion.identity);

            currWaitTime = randWaitTime;
        }
        else
        {
            currWaitTime -= Time.deltaTime*2;
        }
    }
}
