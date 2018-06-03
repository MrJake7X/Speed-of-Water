using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsBehaviour : MonoBehaviour {

    protected int newWeapon;

    protected InputManager inputManager;

    private bool isUp;

    protected int timePowerUp;

    private Vector2 speed;

    private float subidaBajada;

	// Use this for initialization
	protected virtual void Start ()
    {
        inputManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputManager>();

        speed.x = -2;
        speed.y = 2;
    }

    private void Update()
    {
        subidaBajada += Time.deltaTime;
        if(subidaBajada >= 1)
        {
            speed.y *= -1;
            subidaBajada = 0;
        }
        transform.Translate(speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            isUp = true;
            inputManager.weapons.ChangeWeapon(newWeapon);
            FindObjectOfType<AudioManager>().Play("PowerUpSound");
            inputManager.StartPowerUp(isUp, timePowerUp);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
