using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour {

    public PirañaBehaviour father;

    private bool dying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dying = true;
            collision.GetComponent<ShipBehaviour>().Damage(father.collisionDamage);
            father.Dying(dying);
        }
    }
}
