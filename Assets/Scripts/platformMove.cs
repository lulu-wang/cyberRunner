using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{

    public float platformMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.deltaTime * platformMoveSpeed;
        transform.position = new Vector2(transform.position.x - offset, transform.position.y);
    }
}
