using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : ShipBehaviour
{

    public Animator anim;
    public Sprite[] sprites;
    private RotateTransform rotateTransform;

    public int score = 10;

    protected override void Start()
    {
        rotateTransform = GetComponent<RotateTransform>();
        rotateTransform.EnableRotation(true);

        life = 4;
        base.Start();

        anim.enabled = false;   
        rend.sprite = sprites[0];
    }

    protected override void HorizontalMovement()
    {
        base.HorizontalMovement();

        counterToDie += Time.deltaTime;

        if (counterToDie >= 60)
        {
            DestroyMeteor();
        }
    }

    // DESTRUCCIÓN DEL METEOR
    private void DestroyMeteor()
    {
        GetComponent<Collider2D>().enabled = false;

        anim.enabled = true;

        anim.SetTrigger("Destroy");

        gameManager.AddScore(score);

        Destroy(gameObject,1.0f);
    }

    public override void Damage(int hit)
    {
        base.Damage(hit);
        if(life == 3)
        {
            rend.sprite = sprites[1];
        }
        if (life == 2)
        {
            rend.sprite = sprites[2];
        }
        if(life == 1)
        {
            rend.sprite = sprites[3];
        }
    }
    // MUERTE DEL METEOR
    protected override void Dead()
    {
        base.Dead();

        canFly = false;

        box.enabled = false;

        FindObjectOfType<AudioManager>().Play("EnemiesDieSound");

        rotateTransform.EnableRotation(false);
        DestroyMeteor();
    }
    // SE DESTRUYE EL METEOR AL SALIR DE LA PANTALLA
    protected override void ResetShip()
    {
        Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Player")
        {
            Damage(collisionDamage);
            Dead();
        }
    }
}
