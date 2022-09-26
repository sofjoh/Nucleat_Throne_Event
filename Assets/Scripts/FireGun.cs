using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Animator anim;
    public GameEvent onPlayerFire;
    public Transform firePoint;
    public GameObject rifleBulletPrefab;
    public AmmoData ammoData;

    public float bulletSpeed = 30f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(ammoData.ammoAmount > 0) onPlayerFire.TriggerEvent();
        }
    }

    public void RifleFire()
    {
        anim.SetTrigger("Fire");
        var rotation = Quaternion.Euler(0,0,firePoint.rotation.z -90f);
        GameObject rifleBullet = Instantiate(rifleBulletPrefab, firePoint.position, rotation);
        Rigidbody2D rb = rifleBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
