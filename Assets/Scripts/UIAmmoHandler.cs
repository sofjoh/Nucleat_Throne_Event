using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIAmmoHandler : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    public AmmoData rifleAmmo;


    private void Start()
    {
        ammoText.text = "Ammo: " + rifleAmmo.ammoAmount;
    }

    public void reduceAmmoCount()
    {
       if (rifleAmmo.ammoAmount > 0) rifleAmmo.ammoAmount--;
        ammoText.text = "Ammo: " + rifleAmmo.ammoAmount;
        //skriv ut UI ammo
    }
}
