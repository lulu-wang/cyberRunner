using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundLen;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Awake()
    {
        //groundCollider = GetComponent<BoxCollider2D>();
        //groundLen = groundCollider.size.x;
        groundLen = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform.position.x > transform.position.x)
        {
            Vector2 groundOffset = new Vector2(cameraTransform.position.x - transform.position.x, 0);
            transform.position = (Vector2)transform.position + groundOffset;
        }
         else if (cameraTransform.position.x < transform.position.x)
        {
            Vector2 groundOffset = new Vector2(transform.position.x - cameraTransform.position.x, 0);
            transform.position = (Vector2)transform.position - groundOffset;
        }
    }
}
