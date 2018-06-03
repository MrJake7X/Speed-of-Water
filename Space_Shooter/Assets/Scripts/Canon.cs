using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {
   
    protected float cooldown;
    protected float timeCounter;
    protected bool canShot = false;
    
    public Vector2 direction;

    // Use this for initialization
    protected virtual void Start ()
    {
        cooldown = 0.2f;
        
        direction = Vector2.right;
    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        // TIEMPO DE ESPERA PARA DISPARAR
        if (!canShot)
        {
            timeCounter += Time.deltaTime;
            if(timeCounter >= cooldown)
            {
                canShot = true;
            }
        }
	}

    // DISPARO DE BALAS REUTILICADAS
    public virtual void ShotCannon(Cartridge c)
    {
        // CADENCIA
        if(!canShot)
        {
            return;
        }

        canShot = false;
        timeCounter = 0;

        c.GetBullet().ShotBullet(transform.position, direction);
    }
}
