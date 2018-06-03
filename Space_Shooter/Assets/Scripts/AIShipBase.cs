using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipBase : MonoBehaviour {

    public Vector2 direction;

    private ShipBehaviour ship;

	// Use this for initialization
	void Start ()
    {
        Initialize();
    }

    void Initialize()
    {
        ship = GetComponent<ShipBehaviour>();

        direction.y = Random.Range(-direction.y, direction.y);

        ship.setAxis(direction);
        ship.SetFly(true);
    }
}
