using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{Start,Wave,PickingDebuff,Lose};

public class GameManager : MonoBehaviour
{
    public PlayerStats_SO startingStats;
    public PlayerStats_SO runningStats;

    public GameState_SO currentState;

    public Int_SO numberOfEnemies;

    public void Awake(){
      SetUp();
    }

    public void SetUp(){
      runningStats.setAllStats(startingStats);
      ChangeToStart();
      numberOfEnemies.SetData(0);
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
