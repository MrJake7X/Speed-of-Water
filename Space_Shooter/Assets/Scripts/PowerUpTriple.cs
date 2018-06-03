using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTriple : PowerUpsBehaviour
{
    protected override void Start()
    {
        base.Start();
        newWeapon = 1;
        timePowerUp = 7;
    }
}
