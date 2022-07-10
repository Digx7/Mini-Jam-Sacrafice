using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public RectMask2D healthUIMask;
    public TextMeshProUGUI stateUI;
    public TextMeshProUGUI scoreUI1;
    public TextMeshProUGUI scoreUI2;
    public int healthData;
    public int scoreData;

    public GameState_SO gameState;

    private Vector4 newPadding;

    public void Update(){
      //healthUI.text = "" + healthData;
      scoreUI1.text = " " + scoreData;
      scoreUI2.text = " " + scoreData;
      updateGameStateUI();

      updateHealthBarUI();
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

    private void updateHealthBarUI(){
      int value = 150;
      value = value - (healthData * 15);
      newPadding.z = value;

      healthUIMask.padding = newPadding;
    }

}
