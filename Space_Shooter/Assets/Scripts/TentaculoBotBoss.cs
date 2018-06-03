using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaculoBotBoss : BossBehaviour {
    protected override void Dead()
    {
        base.Dead();

        bossManager.KillBot(isDead);

        DestroyBoss();
    }
}
