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


    private void Start()
    {
        originalTimer = timer;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < AttackFieldRadius)
        {
            moveEnemy();
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
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
