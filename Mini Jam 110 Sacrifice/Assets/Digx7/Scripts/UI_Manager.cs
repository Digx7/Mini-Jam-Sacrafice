using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI healthUI;
    public int healthData;

    public void Update(){
      healthUI.text = "" + healthData;
    }

    public void SetHealthData(int input){
      healthData = input;
    }

}
