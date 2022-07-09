using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
  public static int count;
  public UnityEvent allEnemiesDead;

  public void Awake()
  {
      count++;
  }

  public void Die()
  {
      count--;

      if(count == 0) allEnemiesDead.Invoke();
  }
}
