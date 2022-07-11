using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreBoard_Data
{
  public List<int> data;

  public ScoreBoard_Data (ScoreBoard_SO input){
    data = input.data;
  }
}
