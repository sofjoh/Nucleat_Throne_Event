using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
 public int ammoAmount;
 public IntVariable rifleAmmo;
 public GameEvent OnAmmoPickup;
 public float timerForRespawnPickup = 5f;
 private float copytimerForRespawnPickup = 5f;
 private bool timerOn;

 private void Start()
 {
     copytimerForRespawnPickup = timerForRespawnPickup;
 }

 private void OnTriggerEnter2D(Collider2D col)
 { 
     if (col.CompareTag("Player"))
     {
         rifleAmmo.intVariable += ammoAmount;
         OnAmmoPickup.TriggerEvent();
         timerOn = true;
         gameObject.GetComponent<BoxCollider2D>().enabled = false;
         gameObject.GetComponent<SpriteRenderer>().enabled = false;
     }
 }
 
 private void Update()
 {
     if (timerOn)
     {
         timerForRespawnPickup -= Time.deltaTime;
     }

     if (timerForRespawnPickup <= 0)
     {
         timerOn = false;
         timerForRespawnPickup = copytimerForRespawnPickup;
         gameObject.GetComponent<BoxCollider2D>().enabled = true;
         gameObject.GetComponent<SpriteRenderer>().enabled = true;
     }
 }
}
