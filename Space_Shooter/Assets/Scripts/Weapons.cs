using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // ETIQUETA PARA MOSTRAR EN EL INSPECTOR
public struct CartidgePropierties
{
    public GameObject bullet;
    public int maxAmmo;
}

public class Weapons : MonoBehaviour
{
    public Canon[] cannons;
    public int selectedCannon;
    public Cartridge[] cartridge;
    public int selectedCartridge = 0;

    public GameObject bullet;

    public Transform ammo;

    public GameObject[] bulletResources;

    public int maxAmmo = 50;

    private void Start()
    {
        bulletResources = Resources.LoadAll<GameObject>("Prefabs/Bullets");
        cannons = GetComponentsInChildren<Canon>();
        selectedCannon = 0;

        cartridge = new Cartridge[bulletResources.Length];

        Vector2 cartridgePos = ammo.position;
        for(int i = 0; i < cartridge.Length; i++)
        {
            cartridge[i] = new Cartridge(i, bulletResources[i], maxAmmo, ammo, cartridgePos);
            cartridgePos.y -= 1.0f;
        }
    }
    
    public void ChangeWeapon(int weapon)
    {
        selectedCannon = weapon;
        selectedCartridge = selectedCannon;
    }

    public void ResetWeapon()
    {
        selectedCannon = 0;
        selectedCartridge = selectedCannon;
    }

    public void ShotWeapon()
    {
        cannons[selectedCannon].ShotCannon(cartridge[selectedCartridge]);
    }
    public void NextWeapon()
    {
        selectedCannon++;
        if(selectedCannon >= cannons.Length)
        {
            selectedCannon = 0;
        }
        selectedCartridge = selectedCannon;
    }
    public void PreviousWeapon()
    {
        selectedCannon--;
        if(selectedCannon < 0)
        {
            selectedCannon = cannons.Length - 1;
        }
        selectedCartridge = selectedCannon;
    }
}
