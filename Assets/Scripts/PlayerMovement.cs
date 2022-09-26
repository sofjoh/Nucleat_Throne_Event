using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 7f;

    public new Rigidbody2D rigidbody;
    public Animator anim;
    public SpriteRenderer sp;
    public new Camera camera;
    public GameObject aim;
    public GameObject weapon;

    private Vector2 movement;
    private Vector2 mousePos;
    private float angle;
    void Update()
    {
        //value between -1 and 1. 
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

       if (movement.x < 0)
       {
           sp.flipX = true;
       }
       else sp.flipX = false;

       if (angle < -45 || angle > 225)
       {
           sp.flipX = true;
       }
       else sp.flipX = false; 
       anim.SetFloat("Horizontal", movement.x);
       anim.SetFloat("Vertical", movement.y);
       anim.SetFloat("Speed", movement.sqrMagnitude);
       anim.SetFloat("Angle", angle);
    }

    private void FixedUpdate()
    {
        //fixedDeltaTime is amount of time that has lapsed since the last time the function was called. Results in a constant movement speed.
        rigidbody.MovePosition(rigidbody.position + movement.normalized * MoveSpeed * Time.fixedDeltaTime);
        aim.transform.position = mousePos;
        Vector2 lookDir = mousePos - rigidbody.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        weapon.transform.rotation = Quaternion.Euler(0,0,angle - 90f);
    }
}
