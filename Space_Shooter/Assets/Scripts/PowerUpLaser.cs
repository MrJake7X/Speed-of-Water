using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLaser : PowerUpsBehaviour
{
    protected override void Start()
    {
        base.Start();
        newWeapon = 2;
        timePowerUp = 3;
    }
}
