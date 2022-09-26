using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Animator anim;
    public GameEvent onBulletHitEnemy;
    public AmmoData EnemyHealth; 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            onBulletHitEnemy.TriggerEvent();
        }
    }


    public void bulletHitEnemy()
    {
        anim.SetTrigger("Hit");
        EnemyHealth.ammoAmount--;
    }
}
