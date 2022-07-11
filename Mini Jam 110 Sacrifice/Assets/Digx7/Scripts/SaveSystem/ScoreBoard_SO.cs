using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreBoard", menuName = "ScriptableObjects/Data/ScoreBoard", order = 1)]
public class ScoreBoard_SO : ScriptableObject
{
    public List<int> data;

    public int GetHighScore(){
      GetLatestSave();

      return data[0];
    }

    public void AddScore(int newScore){
      GetLatestSave();

      data.Add(newScore);
      data.Sort(CompareLargestToSmallest);
      if(data.Count > 10)data.RemoveAt(10);

      SaveSystem.SaveScore(this);
    }

    public int GetScoreAtIndext(int index){
      if(index < data.Count) return data[index];
      else return 0;
    }

    public void GetLatestSave(){
      data.Clear();

      ScoreBoard_Data new_data = SaveSystem.LoadScore();
      if(new_data != null) data = new_data.data;
    }

    private static int CompareLargestToSmallest(int x, int y){
      if(x > y) return -1;
      else if(x < y) return 1;
      else return 0;
    }
}
