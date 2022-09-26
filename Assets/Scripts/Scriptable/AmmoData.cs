using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ammo data")]
public class AmmoData : ScriptableObject
{
    [HideInInspector] public int ammoAmount;
    public int maxAmmoAmount;

    private void OnEnable()
    {
        ammoAmount = maxAmmoAmount;
    }
}
