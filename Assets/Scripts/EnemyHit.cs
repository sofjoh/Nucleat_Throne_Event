using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Animator anim;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            //event här! Animation, enemy hälsa ner, kanske ljud, bullet träff-animation, delete bullet
            anim.SetTrigger("Hit");
        }
    }
}
