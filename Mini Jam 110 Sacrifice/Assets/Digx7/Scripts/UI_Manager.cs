using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI stateUI;
    public TextMeshProUGUI scoreUI;
    public int healthData;
    public int scoreData;

    public GameState_SO gameState;

    public void Update(){
      healthUI.text = "" + healthData;
      scoreUI.text = " " + scoreData;
      updateGameStateUI();
    }

    public void SetHealthData(int input){
      healthData = input;
    }

    public void UpdateScoreDate(int input){
      scoreData+= input;
    }

    public void updateGameStateUI(){
      switch (gameState.GetCurrentState()) {
        case GameState.Start :
          stateUI.text = "Start";
          break;
        case GameState.Wave :
          stateUI.text = "Wave";
          break;
        case GameState.PickingDebuff :
          stateUI.text = "Picking Debuff";
          break;
        case GameState.Lose :
          stateUI.text = "Lose";
          break;
      }
    }

}
