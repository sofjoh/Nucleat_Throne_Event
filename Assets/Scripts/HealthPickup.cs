using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameEvent healthPickup;
    public int healthAmount = 5;
    public GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            healthPickup.TriggerEvent(healthAmount);
            Destroy(gameObject);
        }
    }
}
