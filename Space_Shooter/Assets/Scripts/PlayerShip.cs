using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : ShipBehaviour
{
    public Sprite[] sprites;

    protected override void Start()
    {
        canFly = true;

        base.Start();

        gameManager.PlayerLife(life);
    }

    protected override void HorizontalMovement()
    {
        if((axis.x < 0 && transform.position.x < -7.5f) || (axis.x > 0 && transform.position.x > 7.5f))
        {
            currentVelocity.x = 0;
            return;
        }
        base.HorizontalMovement();
    }

    protected override void VerticalMovement()
    {
        if((axis.y < 0 && transform.position.y < -4.3f) || (axis.y > 0 && transform.position.y > 4.3f))
        {
            currentVelocity.y = 0;
            return;
        }
        base.VerticalMovement();
    }

    public override void Damage(int hit)
    {
        base.Damage(hit);

        if(life == 4)
        {
            rend.sprite = sprites[0];
        }
        if(life == 3)
        {
            rend.sprite = sprites[1];
        }
        if (life == 2)
        {
            rend.sprite = sprites[1];
        }
        if (life == 1)
        {
            rend.sprite = sprites[2];
        }

        FindObjectOfType<AudioManager>().Play("PlayerDmgSound");

        gameManager.PlayerLife(life);
    }

    protected override void Dead()
    {
        base.Dead();

        FindObjectOfType<AudioManager>().Play("PlayerDieSound");

        gameManager.GameOver();
    }
}
