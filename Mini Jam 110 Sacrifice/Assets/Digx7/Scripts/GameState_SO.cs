using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameState", menuName = "ScriptableObjects/Data/GameState", order = 1)]
public class GameState_SO : ScriptableObject
{
    public GameState currentState;

    public void SetCurrentState(GameState input){
      currentState = input;
    }

    public GameState GetCurrentState(){
      return currentState;
    }

    public void ChangeToStart(){
      SetCurrentState(GameState.Start);
      for(int i = listeners.Count -1; i >= 0; i--)
      listeners[i].OnChangeToStart();
    }

    public void ChangeToWaveState(){
      SetCurrentState(GameState.Wave);
      for(int i = listeners.Count -1; i >= 0; i--)
      listeners[i].OnChangeToWaveState();
    }

    public void ChangeToPickingDebuff(){
      SetCurrentState(GameState.PickingDebuff);
      for(int i = listeners.Count -1; i >= 0; i--)
      listeners[i].OnChangeToPickingDebuff();
    }

    public void ChangeToLose(){
      SetCurrentState(GameState.Lose);
      for(int i = listeners.Count -1; i >= 0; i--)
      listeners[i].OnChangeToLose();
    }

    private List<GameState_Listener> listeners =
  		new List<GameState_Listener>();

    public void RegisterListener(GameState_Listener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(GameState_Listener listener)
    { listeners.Remove(listener); }

}
