using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameEvent healthPickup;
    public int healthAmount = 5;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            healthPickup.TriggerEvent(healthAmount);
            Destroy(gameObject);
        }
    }
}
