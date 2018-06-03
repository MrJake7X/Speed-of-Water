using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEnemies : TitleShip
{

    public GameObject ship;
    public float shipPosX;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        shipPosX = ship.transform.position.x;
		
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
		shipPosX = ship.transform.position.x;

        if(shipPosX >= 0)
        {
            base.Update();
        }
	}
}
