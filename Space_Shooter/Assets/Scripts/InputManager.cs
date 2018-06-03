using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private ShipBehaviour player;

    public Weapons weapons;

    private GameManager gameManager;

    private bool powerUp = false;

    private int cooldownPowerUp;

    private float powerUpCounter;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipBehaviour>();

        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameManager.gamePaused) gameManager.Resume();
            else gameManager.Pause();
        }

        if(gameManager.gamePaused)
        {
            return;
        }

        Vector2 inputAxis = Vector2.zero;
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.y = Input.GetAxis("Vertical");

        // METODO PUBLICO DEL ARCHIVO PLAYERBEHAVIOUR PARA ACTUALIZAR EL AXIS
        player.setAxis(inputAxis);

        // INPUT DISPARO
        if (Input.GetButton("Jump"))
        {
            weapons.ShotWeapon();
        }
        
        if(powerUp)
        {
            powerUpCounter += Time.deltaTime;
            if(powerUpCounter >= cooldownPowerUp)
            {
                weapons.ResetWeapon();
                powerUpCounter = 0;
                powerUp = false;
            }
        }
    }

    public void StartPowerUp(bool power, int cooldown)
    {
        powerUp = power;
        cooldownPowerUp = cooldown;
    }
}