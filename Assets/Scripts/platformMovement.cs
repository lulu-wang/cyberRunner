using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    public GameObject effect;

	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}
}
