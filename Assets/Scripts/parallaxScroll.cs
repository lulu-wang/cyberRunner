using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxScroll : MonoBehaviour
{
    private float bgLen, startPosition;
    public GameObject cam;
    public float parallax;
    public bool scrollRepeat;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        bgLen = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float moveDist = (cam.transform.position.x * parallax);

        transform.position = new Vector3(startPosition + moveDist, 
            transform.position.y, transform.position.z);

        if (scrollRepeat)
        {
            float temp = (cam.transform.position.x * (1 - parallax));
            if (temp >= startPosition + bgLen)
            {
                startPosition += (1.95f * bgLen);
            } else if (temp <= startPosition - bgLen)
            {
                startPosition -= 1.95f * bgLen;
            }
        }

    }
}
