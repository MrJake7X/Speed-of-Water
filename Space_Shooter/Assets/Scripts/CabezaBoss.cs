using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaBoss : BossBehaviour {

    public bool onlyHead;

    public override void Damage(int dmg)
    {
        if(onlyHead)
        {
            base.Damage(dmg);
        }
    }

    protected override void Dead()
    {
        isDead = true;

        bossManager.KillHead(isDead);
    }
}
