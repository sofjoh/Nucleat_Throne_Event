using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
 public int ammoAmount;
 public IntVariable rifleAmmo;
 public GameEvent OnAmmoPickup;


 private void OnTriggerEnter2D(Collider2D col)
 { 
     if (col.CompareTag("Player"))
     {
         rifleAmmo.intVariable += ammoAmount;
         OnAmmoPickup.TriggerEvent();
         Destroy(gameObject);
     }
 }
}
