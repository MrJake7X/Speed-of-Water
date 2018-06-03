using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void ShotBullet(Vector2 origin, Vector2 direccion)
    {
        base.ShotBullet(origin, direccion);
        FindObjectOfType<AudioManager>().Play("BossShotSound");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<ShipBehaviour>().Damage(damage);

            Reset();
        }
        if(collision.tag == "Bullet")
        {
            Reset();
        }
    }
}
