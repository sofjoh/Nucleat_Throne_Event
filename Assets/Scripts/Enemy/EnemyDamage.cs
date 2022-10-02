using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public int Health;
    public Slider sliderEnemyHealth;
    public GameObject enemyHurtEffect;
    
    private void Start()
    {
        sliderEnemyHealth.maxValue = Health;
        sliderEnemyHealth.value = Health;
    }
    
    private void Update()
    {
        if(Health < 1) KillThisEnemy();
    }

    public void damageEnemy(int damage, GameObject gameobject)
    {
        if (gameobject == this.gameObject)
        {
            Instantiate(enemyHurtEffect, transform.position, Quaternion.identity);
            Health -= damage;
            sliderEnemyHealth.value = Health;
        }
    }
    public void KillThisEnemy()
    {
        Destroy(gameObject);
    }
}
