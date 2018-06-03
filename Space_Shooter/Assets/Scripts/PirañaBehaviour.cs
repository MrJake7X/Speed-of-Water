using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirañaBehaviour : ShipBehaviour
{
    public Animator anim;

    public int score = 15;

    public DetectZone detectZone;

    public Vector2 targetPos;

    public Vector2 playerPos;

    private Vector2 enemyPos;

    public bool setTarget;

    public bool flip;

    private bool die;

    protected override void Start()
    {
        base.Start();

        anim.Play("pirana_idle");
    }

    protected override void Update()
    {
        base.Update();

        counterToDie += Time.deltaTime;

        if (counterToDie >= 60)
        {
            DestroyPirana();
        }

        enemyPos = transform.position;

        if(die)
        {
            Dead();
        }

        if (setTarget)
        {

            if(transform.position.x < playerPos.x && flip)
            {
                sprite.flipX = true;
                flip = false;
            }
            if(transform.position.x > playerPos.x && flip)
            {
                sprite.flipX = false;
                flip = false;
            }

            anim.Play("pirana_attack");

            speed.x = 5;
            speed.y = 5;

            setAxis(targetPos);
        }
    }

    private void DestroyPirana()
    {
        gameManager.AddScore(score);

        ExplosionPS.Play();

        Destroy(gameObject, 2.0f);
    }

    protected override void Dead()
    {
        base.Dead();

        sprite.enabled = false;

        box.enabled = false;

        FindObjectOfType<AudioManager>().Play("EnemiesDieSound");

        DestroyPirana();
    }

    public void Dying(bool d)
    {
        die = d;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            setTarget = true;

            flip = true;

            playerPos = collision.transform.position;

            targetPos = playerPos - enemyPos;

            targetPos.Normalize();
        }
    }
}
