using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaculoTopBoss : BossBehaviour {

    protected override void Dead()
    {
        base.Dead();

        bossManager.KillTop(isDead);

        DestroyBoss();
    }
}
