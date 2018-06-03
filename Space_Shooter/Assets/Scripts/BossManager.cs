using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

    private bool deadTop;
    private bool deadBot;
    private bool deadMid;
    private bool deadHead;
    private bool deadTentacle;

    public CabezaBoss head;

    public TentaculoTopBoss top;

    public TentaculoMidBoss mid;

    public TentaculoBotBoss bot;

    public EnemyWeapons enemyWeapons;

    private float cd;

    private Vector2 dir;

    private int speed;

    private GameManager gameManager;

    public Animator anim;

    public int score;

    private bool ready;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        cd = 1.5f;

        anim.Play("boss_cabeza_idle");

        score = 500;

        Reset();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (!ready)
        {
            Reset();
            if(transform.position.x <= 5)
            {
                ready = true;
                dir.x = 0;
                dir.y = 1;
                speed = 2;
                gameManager.BandasAbajo();
            }
        }
        else
        {
            anim.Play("boss_cabeza_attack");
            if (transform.position.y >= 2)
            {
                dir.y = -1;
            }
            if (transform.position.y <= -0.5)
            {
                dir.y = 1;
            }

            enemyWeapons.canon.ChangeCooldown(cd);

            if (deadBot && deadMid && deadTop)
            {
                deadTentacle = true;
                head.onlyHead = true;
                cd = 0.2f;
            }
            if (deadTentacle)
            {
                speed = 5;
                enemyWeapons.ShotWeaponRage();
                if (deadHead)
                {
                    gameManager.AddScore(score);
                    gameManager.bossDead = deadHead;
                    Destroy(gameObject);
                }
            }

            enemyWeapons.ShotWeapon();
        }
    }

    public void KillTop(bool t)
    {
        deadTop = t;
    }

    public void KillMid(bool m)
    {
        deadMid = m;
    }

    public void KillBot(bool b)
    {
        deadBot = b;
    }

    public void KillHead(bool c)
    {
        deadHead = c;
    }

    public void MorePower()
    {
        cd -= 0.5f;
    }

    private void Reset()
    {
        speed = 2;
        dir.y = 0;
        dir.x = -1;
    }
}
