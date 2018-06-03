using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Canon {

	protected override void Start ()
    {
        base.Start();
        cooldown = 0.0f;
    }

	protected override void Update ()
    {
        base.Update();
	}

    public override void ShotCannon(Cartridge c)
    {
        if(!canShot)
        {
            return;
        }

        canShot = false;
        timeCounter = 0;

        c.GetBullet().ShotBullet(transform.position, direction);
    }
}
