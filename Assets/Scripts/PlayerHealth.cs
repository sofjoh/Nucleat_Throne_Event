using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void DamagePlayer(int damage)
    {
        playerHealth.intVariable -= damage;
        sliderPlayerHealth.value = playerHealth.intVariable;
    }
}
