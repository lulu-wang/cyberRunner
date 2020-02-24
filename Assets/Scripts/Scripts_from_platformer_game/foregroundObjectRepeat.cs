using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foregroundObjectRepeat : MonoBehaviour
{
    public float spawnRate = 4f;
    public GameObject objectPrefab;
    public float minX, maxX;

    private int objectNum = 4;
    private GameObject[] foregroundObjects;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private int currObj = 0;
    private float timeSinceLastSpawned;
    // Start is called before the first frame update
    void Start()
    {
        foregroundObjects = new GameObject[objectNum];
        for (int i = 0; i < objectNum; i++)
        {
            Debug.Log(i);

            foregroundObjects[i] = (GameObject)Instantiate(objectPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        //if (timeSinceLastSpawned >= spawnRate)
        //{
        //    timeSinceLastSpawned = 0;
        //    float spawnXPosition = Random.Range(minX, maxX);
        //    Debug.Log(currObj);

        //    foregroundObjects[currObj].transform.position = new Vector2(spawnXPosition, 1.877f);
        //    currObj++;
        //    if (currObj >= objectNum)
        //    {
        //        currObj = 0;
        //    }
        //}

        float spawnXPosition = Random.Range(minX, maxX);
        Debug.Log(currObj);

        foregroundObjects[currObj].transform.position = new Vector2(spawnXPosition, 1.877f);
        currObj++;
        if (currObj >= objectNum)
        {
            currObj = 0;
        }

    }
}
