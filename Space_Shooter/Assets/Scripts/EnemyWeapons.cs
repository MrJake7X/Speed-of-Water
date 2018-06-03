using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // ETIQUETA PARA MOSTRAR EN EL INSPECTOR

public class EnemyWeapons : MonoBehaviour {

    public EnemyCanon canon;

    public EnemyCanon canonRage;

    public Cartridge cartridge;

    public Cartridge cartridgerage;

    public Transform enemyAmmo;

    public GameObject bullet;

    public int maxAmmo = 50;

	// Use this for initialization
	void Start ()
    {
        enemyAmmo = GameObject.FindGameObjectWithTag("enemyammo").GetComponent<Transform>();

        Vector2 cartridgePos = enemyAmmo.position;
        cartridge = new Cartridge((int)Time.time, bullet, maxAmmo, enemyAmmo, cartridgePos);
        cartridgerage = new Cartridge((int)Time.time, bullet, maxAmmo, enemyAmmo, cartridgePos);
    }
	
	public void ShotWeapon()
    {
        canon.ShotCannon(cartridge);
    }

    public void ShotWeaponRage()
    {
        canonRage.ShotCannon(cartridgerage);
    }
}
