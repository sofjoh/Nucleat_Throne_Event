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


    private void Start()
    {
        originalTimer = timer;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
            //fix this. Kolla upp rigid body movement
            rb.velocity = (target.position - transform.position * speed * Time.deltaTime);
            Debug.Log(rb.velocity);
        }
    }

    private void ongoingCollision()
    {
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
}
