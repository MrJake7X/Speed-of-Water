using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge {

    protected Bullet[] bullets;

    // VARIABLES PARA EL CD DEL DISPARO
    protected int currentBullet = 0;
    
    public Cartridge(int index, GameObject bulletprefab, int maxAmmo, Transform parent, Vector2 origin)
    {
        bullets = new Bullet[maxAmmo];
        Vector2 spawnpos = origin;

        for(int i = 0; i < maxAmmo; i++)
        {
            // CREAR BULLET
            GameObject obj = GameObject.Instantiate(bulletprefab, spawnpos, Quaternion.identity, parent);
            spawnpos.x -= 0.2f;

            // CAMBIAR NOMBRE BULLETS
            obj.name = "Cartridge_" + index + "_" + bulletprefab.name + "_" + i;
            // GUARDAR BULLET EN LA POSICION DEL ARRAY
            bullets[i] = obj.GetComponent<Bullet>();
        }
    }

    public Bullet GetBullet()
    {
        Bullet obj = bullets[currentBullet];

        currentBullet++;
        if(currentBullet >= bullets.Length)
        {
            currentBullet = 0;
        }

        return obj;
    }
}
