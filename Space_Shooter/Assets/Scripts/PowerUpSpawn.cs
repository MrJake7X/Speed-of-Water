using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : Spawner {

    public GameObject[] objsToSpawn;

    private int rdmPowerUp;

	// Update is called once per frame
	protected override void Update ()
    {
        rdmPowerUp = Random.Range(0, 3);
        
        objToSpawn= objsToSpawn[rdmPowerUp];

        base.Update();
    }
}
