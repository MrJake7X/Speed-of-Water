using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCanon : Canon
{
    protected int angle1 = 0;
    protected int angle2 = 30;
    protected int angle3 = -30;

    protected override void Start()
    {
        base.Start();
        cooldown = 0.3f;
    }

    public override void ShotCannon(Cartridge c)
    {
        //base.ShotBullet();
        // CADENCIA
        if (!canShot)
        {
            return;
        }

        canShot = false;
        timeCounter = 0;

        c.GetBullet().ShotBullet(transform.position, direction, angle1);
        c.GetBullet().ShotBullet(transform.position, direction, angle2);
        c.GetBullet().ShotBullet(transform.position, direction, angle3);
    }
}
