using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnguilaBehaviour : ShipBehaviour
{
    public Animator anim;

    private float cooldownElectro;

    public float time;

    private bool isElectro = false;

    public int electroDamage;

    private Vector2 iniBoxSize;

    public int score = 25;

    private float hitTime;

    private bool isHit;

    protected override void Start()
    {
        base.Start();
        
        iniBoxSize = box.size;

        time = Random.Range(0,time);

        box.enabled = true;

        anim.Play("anguila_idle");
    }

    protected override void Update()
    {
        base.Update();

        counterToDie += Time.deltaTime;

        if(counterToDie >= 60)
        {
            DestroyAnguile();
        }

        cooldownElectro += Time.deltaTime;

        if(cooldownElectro >= time && !isHit)
        {
            Electro();
            if(cooldownElectro >= time + 1.5f)
            {
                cooldownElectro = 0;
                if(!isDead)
                {
                    ResetAnim();
                }
            }
        }

        if(isHit)
        {
            hitTime += Time.deltaTime;
            if (hitTime >= 0.5f)
            {
                ResetAnim();
                isHit = false;
            }
        }
    }

    private void Electro()
    {
        box.size = new Vector2(2.7f, 1.3f);
        box.offset = new Vector2(0, 0);

        anim.Play("anguila_electro");

        isElectro = true;
    }

    private void ResetAnim()
    {
        anim.Play("anguila_idle");

        box.size = iniBoxSize;

        isElectro = false;
    }

    public override void Damage(int hit)
    {
        base.Damage(hit);

        anim.Play("anguila_hit");
        isHit = true;
    }

    private void DestroyAnguile()
    {
        gameManager.AddScore(score);

        ExplosionPS.Play();

        Destroy(gameObject, 2.0f);
    }

    protected override void Dead()
    {
        base.Dead();

        box.enabled = false;

        sprite.enabled = false;

        FindObjectOfType<AudioManager>().Play("EnemiesDieSound");

        DestroyAnguile();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.tag == "Player")
        {

            if(isElectro)
            {
                Damage(electroDamage);
            }
            else
            {
                Damage(collisionDamage);
            }
            Dead();
        }
    }

}
