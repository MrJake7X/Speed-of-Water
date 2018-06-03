using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaculoMidBoss : BossBehaviour {

    protected override void Dead()
    {
        base.Dead();

        bossManager.KillMid(isDead);

        DestroyBoss();
    }
}
