using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject enemyBullet;

    public float bulletSpeed = 10f;

    public void EnemyFire(GameObject target)
    {
        GameObject EnemyBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = EnemyBullet.GetComponent<Rigidbody2D>();
        rb.transform.right = target.transform.position + new Vector3(0,0.6f,0) - EnemyBullet.transform.position;
        rb.AddForce(rb.transform.right.normalized * bulletSpeed);
    }
}
