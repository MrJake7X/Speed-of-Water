using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMaterialAnimateInicio: OffsetMaterialAnimate
{
    protected override void Start()
    {
        base.Start();

        tileX = 1.0f;
        tileY = 2.0f;
    }

    protected override void Update()
    {
        base.Update();

        offset.x += Time.deltaTime * smooth;

        if(offset.x >= 100)
        {
            offset.x = 0;
        }
    }
}
