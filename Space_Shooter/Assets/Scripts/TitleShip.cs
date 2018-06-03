using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShip : MonoBehaviour {

    protected Vector2 iniPos;
    protected float speed;
    protected float posX;
	
	protected virtual void Start ()
    {
        speed = 5;
        iniPos = transform.position;
        posX = iniPos.x;
	}
	
	protected virtual void Update ()
    {

        posX = speed * Time.deltaTime;
        transform.Translate(posX, 0, 0);

    }
}
