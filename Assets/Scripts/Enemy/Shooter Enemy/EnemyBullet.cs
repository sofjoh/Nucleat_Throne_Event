using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameEvent enemyTakeDamage;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            enemyTakeDamage.TriggerEvent(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
