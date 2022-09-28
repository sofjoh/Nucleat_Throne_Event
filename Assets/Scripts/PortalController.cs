using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private SpriteRenderer sprite;
    public IntVariable enemyCount;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (enemyCount.intVariable <= 0)
        {
            sprite.color = Color.white;
        }
    }
}
