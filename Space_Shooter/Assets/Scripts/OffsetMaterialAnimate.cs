using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMaterialAnimate : MonoBehaviour {

    //private Material material;

    protected Renderer rend;

    protected Vector2 offset;

    public float smooth = 2f;

    protected float tileX;

    protected float tileY;

    // Use this for initialization
    protected virtual void Start ()
    {
        // COGER MATERIAL DEL OBJETO SIN ESTAR LINKADO CREANDO INSTANCIA

        rend = GetComponent<MeshRenderer>();

        tileX = 1.0f;
        tileY = 2.0f;
	}

    // Update is called once per frame
    protected virtual void Update ()
    {
        offset.y -= Time.deltaTime * smooth;
        if(offset.y <= -100)
        {
            offset.y = 0;
        }

        // MODIFICAR MATERIAL SIN CREAR ESTANCIAS
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        rend.GetPropertyBlock(block);

        block.SetVector("_MainTex_ST", new Vector4(tileX, tileY, offset.x, offset.y));

        rend.SetPropertyBlock(block);
	}
}
