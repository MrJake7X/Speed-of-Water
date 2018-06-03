﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet {

    public override void ShotBullet(Vector2 origin, Vector2 direccion)
    {
        base.ShotBullet(origin, direccion);

        FindObjectOfType<AudioManager>().Play("ShootSound");
    }
}
