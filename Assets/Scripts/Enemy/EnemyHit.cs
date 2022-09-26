using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public Animator anim;
    public GameEvent onBulletHitEnemy;
    public AmmoData EnemyHealth;
    public Slider sliderEnemyHealth;

    private void Start()
    {
        sliderEnemyHealth.maxValue = EnemyHealth.ammoAmount;
        sliderEnemyHealth.value = sliderEnemyHealth.maxValue;
    }

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
        sliderEnemyHealth.value = EnemyHealth.ammoAmount;
    }
}
