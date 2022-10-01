using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float AttackFieldRadius;
    public float minDistance;
    private bool collidingWithPlayer = true;
    public float timer = 1;
    private float originalTimer = 1;
    public GameEvent collisionEnemyPlayer;
    private Rigidbody2D rb;
    private Vector2 dir;


    private void Start()
    {
        originalTimer = timer;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dir = target.position - transform.position;

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < AttackFieldRadius)
        {
            moveEnemy();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }


    private void moveEnemy()
    {
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
            ongoingCollision();
        }
        else
        { 
            addForceToEnemy();
        }
    }

    private void ongoingCollision()
    {
        rb.velocity = Vector2.zero;
        if(collidingWithPlayer) collisionEnemyPlayer.TriggerEvent();

        if (timer < 0)
        {
            collidingWithPlayer = true;
            timer = originalTimer;
        }
        else
        {
            collidingWithPlayer = false;
            timer -= Time.deltaTime;
        }

    }

    private void addForceToEnemy()
    {
        {
            rb.velocity = (dir * speed * Time.fixedDeltaTime);
        }
    }
}
