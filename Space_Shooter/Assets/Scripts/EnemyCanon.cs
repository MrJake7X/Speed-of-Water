using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : TripleCanon
{
    public float newCooldown;

    protected override void Start()
    {
        base.Start();
        direction.x = -1;
        cooldown = newCooldown;
        angle2 = 15;
        angle3 = -15;

    }

    protected override void Update()
    {
        base.Update();
        cooldown = newCooldown;
    }

    public void ChangeCooldown(float cd)
    {
        newCooldown = cd;
    }
}
