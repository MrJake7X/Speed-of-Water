using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

    public int damage;

    protected bool shot = false;

    private Vector2 iniPos;

    protected Vector2 dir;

	// Use this for initialization
	protected virtual void Start ()
    {
        iniPos = transform.position;
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
		if(shot)
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
	}

    public virtual void ShotBullet(Vector2 origin, Vector2 direccion)
    {
        shot = true;
        transform.position = origin;
        dir = direccion;
    }
    // SOBRECARGA DE SHOT PARA TENER MAS PARAMETROS DISTINTOS
    public virtual void ShotBullet(Vector2 origin, Vector2 direccion, float zRot)
    {
        ShotBullet(origin, direccion);

        // ROTACION EN GRADOS EULER
        transform.rotation = Quaternion.Euler(0, 0, zRot);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Boundary")
        {
            Reset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            collision.GetComponent<ShipBehaviour>().Damage(damage);

            Reset();
        }

        if(collision.tag == "killZone")
        {
            collision.GetComponent<DetectZone>().father.Damage(damage);

            Reset();
        }

        if(collision.tag == "Boss")
        {
            collision.GetComponent<BossBehaviour>().Damage(damage);

            Reset();
        }

        if (collision.tag == "PowerUp")
        {
            Reset();
        }
    }

    protected void Reset()
    {
        shot = false;
        transform.position = iniPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
