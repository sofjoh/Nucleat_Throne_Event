using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public Animator anim;
    public int Health;
    public Slider sliderEnemyHealth;

    private void Start()
    {
        sliderEnemyHealth.maxValue = Health;
        sliderEnemyHealth.value = Health;
    }

    private void Update()
    {
        if(Health < 1) KillThisEnemy();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("Hit");
            Health--;
            sliderEnemyHealth.value = Health;
        }
    }
    
    public void KillThisEnemy()
    {
        Destroy(gameObject);
    }

}
