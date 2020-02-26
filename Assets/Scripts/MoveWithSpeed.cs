using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithSpeed : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.deltaTime * moveSpeed;
        transform.position = new Vector2(transform.position.x - offset, transform.position.y);
    }
}
