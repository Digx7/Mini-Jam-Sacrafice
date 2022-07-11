using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Score : MonoBehaviour
{
    public Int_SO score;
    public ScoreBoard_SO scoreBoard;

    public void increaseScore(){
      score.UpdateData(1);
    }

    public void ResetScore(){
      score.SetData(0);
    }

    public void saveScore(){
      scoreBoard.AddScore(score.GetData());
    }

    public void loadScore(){
      scoreBoard.GetLatestSave();
    }

    [ContextMenu("DeleteScore")]
    public void DeleteScore(){
      SaveSystem.DeleteScore();
    }
}
