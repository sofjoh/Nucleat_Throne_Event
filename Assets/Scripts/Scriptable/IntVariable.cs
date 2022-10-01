using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Int Variable")]
public class IntVariable : ScriptableObject
{
     [HideInInspector] public int intVariable;
    public int maxIntVariable;

    private void OnEnable()
    {
        intVariable = maxIntVariable;
    }
}
