using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesSpawner : MonoBehaviour {
    private Vector2 iniPos;
    public float posY;
    private int speed;

	// Use this for initialization
	void Start ()
    {
        speed = 7;
        posY = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        posY = speed * Time.deltaTime;
        transform.Translate(0, posY, 0);

        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
	}
}
