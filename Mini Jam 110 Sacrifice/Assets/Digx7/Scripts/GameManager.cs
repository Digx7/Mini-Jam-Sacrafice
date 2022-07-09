using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{Start,Wave,PickingDebuff,Lose};

public class GameManager : MonoBehaviour
{
    public PlayerStats_SO startingStats;
    public PlayerStats_SO runningStats;

    public GameState_SO currentState;

    public void Awake(){
      SetUp();
    }

    public void SetUp(){
      runningStats.setAllStats(startingStats);
      ChangeToStart();
    }

    public void SetGameState(GameState input){
      currentState.SetCurrentState(input);
    }

    public void ChangeToStart(){
      currentState.SetCurrentState(GameState.Start);
    }

    public void ChangeToWaveState(){
      currentState.SetCurrentState(GameState.Wave);
    }

    public void ChangeToPickingDebuff(){
      currentState.SetCurrentState(GameState.PickingDebuff);
    }

    public void ChangeToLose(){
      currentState.SetCurrentState(GameState.Lose);
    }
}
