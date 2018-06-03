using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject objToSpawn;
    public float minTime;
    public float maxTime;
    public float deltaPosY;
    private float timeCounter;
    private float timeSpawn;

	// Use this for initialization
	void Start ()
    {
        timeSpawn = minTime;
        timeCounter = 0;
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
		if(timeCounter >= timeSpawn)
        {
            Spawn();
        }
        else
        {
            timeCounter += Time.deltaTime;
        }
	}

    void Spawn()
    {
        timeCounter = 0;
        timeSpawn = Random.Range(minTime, maxTime);

        Vector2 spawnPos = transform.position;
        spawnPos.y += Random.Range(-deltaPosY, deltaPosY);

        GameObject obj = Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        obj.name = objToSpawn.name + "_" + Time.time.ToString("00.00");
    }

}
