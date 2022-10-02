using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 5;
    public GameEvent OnAmmoPickup;
 public float timerForRespawnPickup = 5f;
 private float copytimerForRespawnPickup = 5f;
 private bool timerOn;
 public GameObject pickupEffect;
 public GameObject particles;

 private void Start()
 {
     copytimerForRespawnPickup = timerForRespawnPickup;
 }

 private void OnTriggerEnter2D(Collider2D col)
 { 
     if (col.CompareTag("Player"))
     {
         Instantiate(pickupEffect, transform.position, quaternion.identity);
         OnAmmoPickup.TriggerEvent(ammoAmount);
         timerOn = true;
         gameObject.GetComponent<BoxCollider2D>().enabled = false;
         gameObject.GetComponent<SpriteRenderer>().enabled = false;
         particles.gameObject.SetActive(false);
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
         particles.gameObject.SetActive(true);
     }
 }
}
