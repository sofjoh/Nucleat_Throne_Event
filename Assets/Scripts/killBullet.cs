using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBullet : MonoBehaviour
{
    public float bulletLifetime = 5f;
    private float timer;
    public Animator bulletAnimator;
    void Start()
    {
        timer = bulletLifetime;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            DestroyBullet();
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            bulletAnimator.SetTrigger("Destroy");
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            bulletAnimator.SetTrigger("Destroy");
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
}
