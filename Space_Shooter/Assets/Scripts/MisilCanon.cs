using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilCanon : Canon
{
    protected override void Start()
    {
        base.Start();
        cooldown = 1.0f;
    }
}
