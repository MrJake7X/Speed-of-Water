using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMisil : PowerUpsBehaviour {
    protected override void Start()
    {
        base.Start();
        newWeapon = 3;
        timePowerUp = 5;
    }
}
