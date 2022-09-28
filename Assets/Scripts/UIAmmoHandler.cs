using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIAmmoHandler : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    public IntVariable rifleAmmo;


    private void Start()
    {
        ammoText.text = "Ammo: " + rifleAmmo.intVariable;
    }

    public void reduceAmmoCount()
    {
       if (rifleAmmo.intVariable > 0) rifleAmmo.intVariable--;
        ammoText.text = "Ammo: " + rifleAmmo.intVariable;
    }


    public void onAmmoPickup()
    {
        ammoText.text = "Ammo: " + rifleAmmo.intVariable;
    }
}
