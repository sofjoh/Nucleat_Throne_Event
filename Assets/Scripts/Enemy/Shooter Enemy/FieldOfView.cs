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
    private void Start()
    {
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds (0.2f);

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

//DONE steg 1: få den att röra sig 
//steg 2: få den att skjuta bullets
//steg 3: få det att se snyggt ut.
//sätt rätt animation för hur fienden rör sig. I movement script.
//när den ser spelaren och ska "spotta", sätt rätt animation/sprite så att den är riktad mot spelaren. 
//trigga event när can see player == true. Skjut bullet. 
