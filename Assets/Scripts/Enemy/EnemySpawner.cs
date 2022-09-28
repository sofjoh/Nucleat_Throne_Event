using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public IntVariable enemyCount;
  private void Awake()
  {
    enemyCount.intVariable++;
  }

  private void OnDestroy()
  {
    enemyCount.intVariable--;
  }
}
