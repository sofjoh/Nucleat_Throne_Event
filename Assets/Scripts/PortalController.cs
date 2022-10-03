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
    public GameEvent playPortalSound;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (enemyCount.intVariable <= 0 && !portalIsActive)
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
                startFinishedLevel();
            }
        }
    }

    private void ActivatePortal()
    {
        portalIsActive = true;
        sprite.enabled = false;
        Instantiate(portal, transform.position, Quaternion.identity);
    }

    IEnumerator LevelFinished()
    {
        playPortalSound.TriggerEvent();
        yield return new WaitForSeconds(2);
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneBuildIndex: i + 1);
    }
    
    public void startFinishedLevel()
    {
        StartCoroutine(LevelFinished());
    }
}
