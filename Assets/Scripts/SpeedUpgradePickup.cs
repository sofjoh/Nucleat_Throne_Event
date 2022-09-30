using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradePickup : MonoBehaviour
{
    public GameEvent SpeedUpgrade;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SpeedUpgrade.TriggerEvent();
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
