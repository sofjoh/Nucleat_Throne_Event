using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    private SpriteRenderer sprite;
    public IntVariable enemyCount;
    private bool portalIsActive;
    public GameObject portal;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (enemyCount.intVariable <= 0)
        {
            ActivatePortal();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (portalIsActive)
        {
            if (col.CompareTag("Player"))
            {
                int i = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneBuildIndex: i + 1);
            }
        }
    }

    private void ActivatePortal()
    {
        portalIsActive = true;
        sprite.enabled = false;
        Instantiate(portal, transform.position, Quaternion.identity);
    }
}
