using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject sceneToggler;
    public Transform target;

    BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = sceneToggler.GetComponent<BoxCollider2D>();
        Debug.Log(col.size.x);
    }

    // Update is called once per frame
    void Update()
    {

        float clampX = Mathf.Clamp(target.transform.position.x, 0.8f, sceneToggler.transform.position.x - 13f);

        Vector3 position = transform.position;
        position.x = clampX;
        position.y = transform.position.y;
        transform.position = position;
    }
}
