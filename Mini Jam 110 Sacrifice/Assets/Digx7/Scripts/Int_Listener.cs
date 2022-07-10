using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Int_Listener : MonoBehaviour
{
  public Int_SO data;
  public UnityEvent hitZero;

  private void OnEnable()
  { data.RegisterListener(this); }

  private void OnDisable()
  { data.UnregisterListener(this); }

  public void OnDataHitZero(){
    hitZero.Invoke();
  }
}
