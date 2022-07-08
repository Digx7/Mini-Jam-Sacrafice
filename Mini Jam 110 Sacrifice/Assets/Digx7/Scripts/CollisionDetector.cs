using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{

  public string tagToWatchFor;

  public UnityEvent Collided;

  void OnCollisionEnter2D(Collision2D col)
  {
      //Debug.Log("Collision Detected");

      if (col.gameObject.tag == tagToWatchFor)
      {
          //Debug.Log("Right tag heard");
          Collided.Invoke();
      }
  }

  void OnTriggerEnter2D(Collider2D col){
    if (col.gameObject.tag == tagToWatchFor)
    {
        //Debug.Log("Right tag heard");
        Collided.Invoke();
    }
  }


}
