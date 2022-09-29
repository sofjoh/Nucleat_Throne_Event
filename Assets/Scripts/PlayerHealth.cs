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
        playerHealth.intVariable -= damage;
        sliderPlayerHealth.value = playerHealth.intVariable;
    }
}
