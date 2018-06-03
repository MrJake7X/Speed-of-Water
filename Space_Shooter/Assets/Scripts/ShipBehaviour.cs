using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour {

    public Vector2 speed;

    protected Vector2 iniPos;

    private TrailRenderer trail;

    protected SpriteRenderer rend;

    public int life;

    protected int iniLife;

    public int collisionDamage;

    protected Vector2 axis;

    //PARTICLE SYSTEM DEAD
    public ParticleSystem ExplosionPS;

    //SOLO SE USARA PARA BORRAR EL SPRITE CUANDO MUERA EL ENEMIGO

    public SpriteRenderer sprite;

    public BoxCollider2D box;

    // DIRECCION EN LA QUE NOS MOVEMOS Y LA CANTIDAD
    protected Vector2 currentVelocity;

    protected bool canFly = false;

    protected bool isDead = false;

    protected GameManager gameManager;

    protected float counterToDie;

    // Use this for initialization
    protected virtual void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        rend = GetComponentInChildren<SpriteRenderer>();

        iniPos = transform.position;

        iniLife = life;
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if(!canFly)
        {
            return;
        }

        HorizontalMovement();
        VerticalMovement();

        // MOVE PLAYER CON EL SPACCE WORLD SE MUEVE EN LOS EJES DEL MUNDO Y NO LOS LOCALES
        transform.Translate(currentVelocity * Time.deltaTime, Space.World);
	}
    // METODO PUBLICO PARA ACTUALIZAR VALOR DE AXIS SIN TENER QUE HACER LA VARIABLE PUBLICA
    public void setAxis(Vector2 newAxis)
    {
        axis = newAxis;
    }

    protected virtual void HorizontalMovement()
    {
        currentVelocity.x = axis.x * speed.x;
    }

    protected virtual void VerticalMovement()
    {
        currentVelocity.y = axis.y * speed.y;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isDead)
        {
            return;
        }

        if(collision.tag == "Boundary")
        {
            ResetShip();
        }
    }

    public void SetFly(bool f)
    {
        canFly = f;
    }

    protected virtual void ResetShip()
    {
        transform.position = iniPos;
        canFly = false;
        life = iniLife;
    }

    public virtual void Damage(int hit)
    {
        life -= hit;
        if(life <= 0)
        {
            life = 0;
            Dead();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    protected virtual void Dead()
    {
        isDead = true;
    }
}
