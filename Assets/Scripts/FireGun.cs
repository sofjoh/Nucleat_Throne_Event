using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Animator anim;
    public GameEvent onPlayerFire;
    public Transform firePoint;
    public GameObject rifleBulletPrefab;
    public IntVariable ammoData;
    private float angle;
    public GameObject playermovement;

    public float bulletSpeed = 30f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(ammoData.intVariable > 0) onPlayerFire.TriggerEvent();
        }
    }

    public void RifleFire()
    {
        angle = playermovement.GetComponent<PlayerMovement>().angle;
        anim.SetTrigger("Fire");
        var rotation = Quaternion.Euler(0,0,angle -90);
        GameObject rifleBullet = Instantiate(rifleBulletPrefab, firePoint.position, rotation);
        Rigidbody2D rb = rifleBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
