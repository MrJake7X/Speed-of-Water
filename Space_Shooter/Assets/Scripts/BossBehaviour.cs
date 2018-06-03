using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    public int life;

    public BossManager bossManager;

    protected bool isDead;

    public GameObject gameObjectBoss;

    public virtual void Damage(int dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            life = 0;
            Dead();
        }
    }

    protected virtual void DestroyBoss()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Dead()
    {
        isDead = true;
        bossManager.MorePower();
    }
}
