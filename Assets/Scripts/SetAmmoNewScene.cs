using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAmmoNewScene : MonoBehaviour
{

    public IntVariable ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo.intVariable = ammo.maxIntVariable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
