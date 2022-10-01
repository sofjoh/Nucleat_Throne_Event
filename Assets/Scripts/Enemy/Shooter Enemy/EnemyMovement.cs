using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;
    public float speed;
    private Rigidbody2D rb;
    private bool collided;
    private SpriteRenderer sp;
    private FieldOfView _fieldOfView;

    private void Start()
    {
        currentPoint = 0;
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _fieldOfView = gameObject.GetComponent<FieldOfView>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            collided = true;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        collided = false;
    }

    private void Update()
    {
        if (!collided && _fieldOfView.CanSeePlayer == false)
            {
                if (transform.position != patrolPoints[currentPoint].position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position,
                        speed * Time.deltaTime);

                    var direction = patrolPoints[currentPoint].position - transform.position;
                    direction = direction.normalized;
                    if (direction.x >= 0)
                    {
                        //transform.localScale = new Vector3(body.transform.localScale.x * -1, body.transform.localScale.y, 1);
                    }
                    else
                    {
                        //transform.localScale = new Vector3(1, body.transform.localScale.y, 1);
                    }
                }
                else
                {
                    currentPoint = (currentPoint + 1) % patrolPoints.Length;
                }
            }
    }
}
