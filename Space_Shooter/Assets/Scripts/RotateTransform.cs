using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTransform : MonoBehaviour {

    private float zRot;

    public float smooth;

    private bool canRotate;

	// Use this for initialization
	void Start ()
    {
        // INT coge el valor minimo y excluye el maximo, en cambio un FLOAT coge ambos
        smooth = Random.Range(-smooth, smooth);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!canRotate)
        {
            return;
        }

        transform.rotation = Quaternion.Euler(0, 0, zRot);

        zRot += Time.deltaTime * smooth;
	}

    public void EnableRotation(bool e)
    {
        canRotate = e;
    }
}
