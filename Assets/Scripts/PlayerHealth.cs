using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public IntVariable playerHealth;
    public Slider sliderPlayerHealth;
    public Animator anim;


    private void Start()
    {
        sliderPlayerHealth.maxValue = playerHealth.intVariable;
        sliderPlayerHealth.value = playerHealth.intVariable;
    }

    private void Update()
    {
        PlayerDied();
    }

    private void PlayerDied()
    {
        if (playerHealth.intVariable <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void DamagePlayer(int damage)
    {
        anim.SetTrigger("PlayerHit");
        playerHealth.intVariable -= damage;
        sliderPlayerHealth.value = playerHealth.intVariable;
    }
    
    public void HealPlayer(int health)
    {
        playerHealth.intVariable += health;
        if (playerHealth.intVariable > playerHealth.maxIntVariable)
        {
            playerHealth.intVariable = playerHealth.maxIntVariable;
        }
        sliderPlayerHealth.value = playerHealth.intVariable;
    }
}
