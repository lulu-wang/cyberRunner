using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMove : MonoBehaviour
{

    public float bgScrollSpeed;
    public float endX;
    public float startX;
    // Update is called once per frame
    void Update()
    {
        float offset = Time.deltaTime * bgScrollSpeed;
        transform.position = new Vector2(transform.position.x - offset, transform.position.y);

        if (transform.position.x <= endX)
		{
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
		}


    }

}
