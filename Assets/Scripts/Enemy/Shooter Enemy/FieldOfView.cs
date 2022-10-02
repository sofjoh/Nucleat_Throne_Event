using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius = 5f;
    [Range(1,360)]public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask ostructionLayer;
    public GameEvent EnemyShoot;
    public bool CanSeePlayer;
    public float shootingFrequency = 0.3f;
    private void Start()
    {
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds (shootingFrequency);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, dirToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, dirToTarget, distanceToTarget, ostructionLayer))
                {
                    CanSeePlayer = true;
                    EnemyShoot.TriggerEvent(target.gameObject);
                }
                else
                {
                    CanSeePlayer = false;
                }
            }

            else
            {
                CanSeePlayer = false;
            }
        }
        
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }
    }
}
