using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;
    public float speed;

    private void Start()
    {
        currentPoint = 0;
    }

    private void Update()
    {
        //kolla om den krockar med spelaren --> i så fall ska den stå stilla. rigidbody.velocity = vector.zero?
        if (transform.position != patrolPoints[currentPoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
                speed * Time.deltaTime);
        }
        else
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
}
