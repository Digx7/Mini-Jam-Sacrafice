using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState_Listener : MonoBehaviour
{

  public GameState_SO State;

  public UnityEvent ChangeToStart;
  public UnityEvent ChangeToWaveState;
  public UnityEvent ChangeToPickingDebuff;
  public UnityEvent ChangeToLose;

  private void OnEnable()
  { State.RegisterListener(this); }

  private void OnDisable()
  { State.UnregisterListener(this); }



  public void OnChangeToStart(){
    ChangeToStart.Invoke();
  }

  public void OnChangeToWaveState(){
    ChangeToWaveState.Invoke();
  }

  public void OnChangeToPickingDebuff(){
    ChangeToPickingDebuff.Invoke();
  }

  public void OnChangeToLose(){
    ChangeToLose.Invoke();
  }
}
