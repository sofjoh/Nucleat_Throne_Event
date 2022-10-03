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
    public Vector2 offset = new Vector2(0, 0.5f);

    private Vector2 movement;
    private Vector2 mousePos;
    [HideInInspector] public float angle;
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
        rigidbody.MovePosition(rigidbody.position + movement.normalized * MoveSpeed * Time.fixedDeltaTime);
        aim.transform.position = mousePos;
        Vector2 lookDir = mousePos - rigidbody.position - offset;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        weapon.transform.rotation = Quaternion.Euler(0,0,angle - 90f);
    }

    public IEnumerator speedPowerUp()
    {
        MoveSpeed *= 1.5f;
        yield return new WaitForSeconds(4);
        MoveSpeed /= 1.5f;
    }

    public void startTheSpeedPickup()
    {
        StartCoroutine(speedPowerUp());
    }

    public void Vanish()
    {
        anim.SetTrigger("Vanish");
        MoveSpeed = 0;
    }
}
